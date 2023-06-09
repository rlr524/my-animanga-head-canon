/* 
* MongoSuggestionData.cs
* Suggestion data handler
* rlr52 | rob@emiyaconsulting.com
* net6.0
* Created 3/19/2023 5:36:45 PM
*/

namespace MyAnimangaAppLibrary.DataAccess;

public class MongoSuggestionData : ISuggestionData
{
    private readonly IDbConnection _db;
    private readonly IUserData _userData;
    private readonly IMemoryCache _cache;
    private readonly IMongoCollection<SuggestionModel> _suggestions;
    private const string CacheName = "SuggestionData";

    public MongoSuggestionData(IDbConnection db, IUserData userData, IMemoryCache cache)
    {
        _db = db;
        _userData = userData;
        _cache = cache;
        _suggestions = db.SuggestionCollection;
    }

    public async Task<List<SuggestionModel>> GetAllSuggestions()
    {
        var output = _cache.Get<List<SuggestionModel>>(CacheName);
        if (output is null)
        {
            var results = await _suggestions.FindAsync(s => s.SuggestionStatus != null && s.SuggestionName != "archived");
            output = results.ToList();

            _cache.Set(CacheName, output, Globals.OneMinute);
        }

        return output;
    }

    public async Task<List<SuggestionModel>> GetAllApprovedSuggestions()
    {
        var output = await GetAllSuggestions();
        return output.Where(s => s.SuggestionStatus != null && s.SuggestionName != "rejected").ToList();
    }

    public async Task<SuggestionModel> GetSuggestion(string id)
    {
        var results = await _suggestions.FindAsync(s => s.Id == id);
        return results.FirstOrDefault();
    }

    public async Task<List<SuggestionModel>> GetAllTopVoteGetters()
    {
        var output = await GetAllSuggestions();
        return output.Where(s => s.TopVoteGetter).ToList();
    }

    public async Task UpdateSuggestion(SuggestionModel suggestion)
    {
        await _suggestions.ReplaceOneAsync(s => s.Id == suggestion.Id, suggestion);
        _cache.Remove(CacheName);
    }

    public async Task UpvoteSuggestion(string suggestionId, string userId)
    {
        var client = _db.Client;

        // There are two transactions committed by this handler, one to the Suggestions collection and one to the
        // User collection. Both transactions need to succeed or both need to fail. To accomplish this, create
        // a client instance of the db for starting an asynchronous db session, instead of just calling the
        // standard db connection that's being used in the other handlers.
        using var session = await client.StartSessionAsync();
        session.StartTransaction();

        try
        {
            var db = client.GetDatabase(_db.DbName);
            var suggestionsInTransaction = db.GetCollection<SuggestionModel>(_db.SuggestionCollectionName);
            var suggestion = (await suggestionsInTransaction.FindAsync(s => s.Id == suggestionId)).First();

            bool isUpvote = suggestion.UserVotes.Add(userId);
            if (!isUpvote)
            {
                suggestion.UserVotes.Remove(userId);
            }

            await suggestionsInTransaction.ReplaceOneAsync(s => s.Id == suggestionId, suggestion);

            var usersInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
            var user = await _userData.GetUser(suggestion.Author.Id);

            if (isUpvote)
            {
                user.VotedOnSuggestions.Add(new BasicSuggestionModel(suggestion));
            }
            else
            {
                var suggestionToRemove = user.VotedOnSuggestions.First(s => s.Id == suggestionId);
                user.VotedOnSuggestions.Remove(suggestionToRemove);
            }

            await usersInTransaction.ReplaceOneAsync(u => u.Id == userId, user);

            await session.CommitTransactionAsync();

            _cache.Remove(CacheName);
        }
        catch (Exception ex)
        {
            await using (StreamWriter writer = new(Globals.LogPath))
            {
                await writer.WriteLineAsync($"{Globals.Now} - Error committing suggestion upvote: {ex}");
            }

            await session.AbortTransactionAsync();
            throw;
        }
    }

    public async Task CreateSuggestion(SuggestionModel suggestion)
    {
        var client = _db.Client;

        using var session = await client.StartSessionAsync();

        session.StartTransaction();

        try
        {
            var db = client.GetDatabase(_db.DbName);
            var suggestionsInTransaction = db.GetCollection<SuggestionModel>(_db.SuggestionCollectionName);
            await suggestionsInTransaction.InsertOneAsync(suggestion);

            var usersInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
            var user = await _userData.GetUser(suggestion.Author.Id);
            user.AuthoredSuggestions.Add(new BasicSuggestionModel(suggestion));
            await usersInTransaction.ReplaceOneAsync(u => u.Id == user.Id, user);

            await session.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            await using (StreamWriter writer = new(Globals.LogPath))
            {
                await writer.WriteLineAsync($"{Globals.Now} - Error commiting new suggestion: {ex}");
            }

            await session.AbortTransactionAsync();
            throw;
        }
    }
}

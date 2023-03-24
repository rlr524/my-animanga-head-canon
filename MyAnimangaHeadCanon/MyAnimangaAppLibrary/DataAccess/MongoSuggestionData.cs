/* 
* MongoSuggestionData.cs
* Suggestion data handler
* rlr52 | rob@emiyaconsulting.com
* net6.0
* Created 3/19/2023 5:36:45 PM
*/

using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver.Linq;

namespace MyAnimangaAppLibrary.DataAccess;
public class MongoSuggestionData
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
            var results = await _suggestions.FindAsync(s => !s.Archived);
            output = results.ToList();

            _cache.Set(CacheName, output, Globals.OneMinute);
        }
        
        return output;
    }

    public async Task<List<SuggestionModel>> GetAllApprovedSuggestions()
    {
        var output = await GetAllSuggestions();
        return output.Where(s => !s.Rejected).ToList();
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
}

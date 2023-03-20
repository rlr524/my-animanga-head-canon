/* 
* MongoSuggestionData.cs
* Suggestion data handler
* rlr52 | rob@emiyaconsulting.com
* net6.0
* Created 3/19/2023 5:36:45 PM
*/

using Microsoft.Extensions.Caching.Memory;

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
}

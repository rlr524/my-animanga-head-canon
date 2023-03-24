/* 
* MongoStatusData.cs
* Controllers library for Status collection
* rlr52 | rob@emiyaconsulting.com
* net6.0
* Created 2/12/2023 8:25:00 PM
*/

using Microsoft.Extensions.Caching.Memory;

namespace MyAnimangaAppLibrary.DataAccess;
public class MongoStatusData : IStatusData
{
    private readonly IMongoCollection<StatusModel> _statuses;
    private readonly IMemoryCache _cache;
    private const string CacheName = "StatusData";

    public MongoStatusData(IDbConnection db, IMemoryCache cache)
    {
        _cache = cache;
        _statuses = db.StatusCollection;
    }

    public async Task<List<StatusModel>> GetAllStatuses()
    {
        var output = _cache.Get<List<StatusModel>>(CacheName);
        if (output is null)
        {
            var results = await _statuses.FindAsync(_ => true);
            output = results.ToList();

            _cache.Set(CacheName, output, Globals.OneDay);
        }
        return output;
    }

    public Task CreateStatus(StatusModel status)
    {
        return _statuses.InsertOneAsync(status);
    }
}

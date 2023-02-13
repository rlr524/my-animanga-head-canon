/** 
 * MongoSourceData.cs
 * *****Description of module*****
 * rlr52 | rob@emiyaconsulting.com
 * net6.0
 * Created 2/12/2023 8:56:53 PM
 */

namespace MyAnimangaAppLibrary.DataAccess;
public class MongoSourceData : ISourceData
{
    private readonly IMongoCollection<SourceModel> _sources;

    public MongoSourceData(IDbConnection db)
    {
        _sources = db.SourceCollection;
    }

    public async Task<List<SourceModel>> GetSourcesAsync()
    {
        var results = await _sources.FindAsync(_ => true);
        return results.ToList();
    }

    public async Task<SourceModel> GetSource(string id)
    {
        var results = await _sources.FindAsync(u => u.Id == id);
        return results.FirstOrDefault();
    }

    public Task CreateSource(SourceModel source)
    {
        return _sources.InsertOneAsync(source);
    }

    public Task UpdateUser(SourceModel source)
    {
        var filter = Builders<SourceModel>.Filter.Eq("Id", source.Id);
        return _sources.ReplaceOneAsync(filter, source, new ReplaceOptions { IsUpsert = true });
    }
}

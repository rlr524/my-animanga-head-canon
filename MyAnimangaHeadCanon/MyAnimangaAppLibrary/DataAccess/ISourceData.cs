/* 
 * MongoSourceData.cs
 * *****Description of module*****
 * rlr52 | rob@emiyaconsulting.com
 * net6.0
 * Created 2/12/2023 8:56:53 PM
 */

namespace MyAnimangaAppLibrary.DataAccess;

public interface ISourceData
{
    Task CreateSource(SourceModel source);
    Task<SourceModel> GetSource(string id);
    Task<List<SourceModel>> GetSourcesAsync();
    Task UpdateUser(SourceModel source);
}
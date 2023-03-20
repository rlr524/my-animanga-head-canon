/* 
* MongoStatusData.cs
* Controllers library for Status collection
* rlr52 | rob@emiyaconsulting.com
* net6.0
* Created 2/12/2023 8:25:00 PM
*/

namespace MyAnimangaAppLibrary.DataAccess;

public interface IStatusData
{
    Task CreateStatus(StatusModel status);
    Task<List<StatusModel>> GetAllStatuses();
}
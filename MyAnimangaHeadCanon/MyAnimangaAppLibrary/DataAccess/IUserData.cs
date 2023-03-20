/* 
 * IUserData.cs
 * Interface for controllers library for Category collection
 * rlr52 | rob@emiyaconsulting.com
 * net6.0
 * Created 2/7/2023 2:15:36 PM
 */

namespace MyAnimangaAppLibrary.DataAccess;

public interface IUserData
{
    Task CreateUser(UserModel user);
    Task<UserModel> GetUser(string id);
    Task<UserModel> GetUserFromAuthentication(string objectId);
    Task<List<UserModel>> GetUsersAsync();
    Task UpdateUser(UserModel user);
}
/*
 * MongoUserData.cs
 * Controllers library for User collection
 * robranf | rob@emiyaconsulting.com
 * net6.0
 * Created 2/7/2023 2:18:42 PM
 */

namespace MyAnimangaAppLibrary.DataAccess;
public class MongoUserData : IUserData
{
    // _users is a copy of a reference to the db.UserCollection, not a copy of the actual collection
    private readonly IMongoCollection<UserModel> _users;

    public MongoUserData(IDbConnection db)
    {
        _users = db.UserCollection;

    }

    public async Task<List<UserModel>> GetUsersAsync()
    {
        // Returns all records, same as just saying FindAsync(users) in that the _ => true is
        // simply testing for if the user record exists. This is the way of doing a where clause
        // in  we're not using an ORM / ODM like Mongoose, but the plain Mongo driver.
        var results = await _users.FindAsync(_ => true);
        return results.ToList();
    }

    public async Task<UserModel> GetUser(string id)
    {
        var results = await _users.FindAsync(u => u.Id == id);
        return results.FirstOrDefault();
    }

    public async Task<UserModel> GetUserFromAuthentication(string objectId)
    {
        var results = await _users.FindAsync(u => u.ObjectIdentifier == objectId);
        return results.FirstOrDefault();
    }

    public Task CreateUser(UserModel user)
    {
        return _users.InsertOneAsync(user);
    }

    public Task UpdateUser(UserModel user)
    {
        var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
        return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
    }
}


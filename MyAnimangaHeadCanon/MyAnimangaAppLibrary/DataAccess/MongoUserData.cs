// MongoUserData.cs
// robranf | rlr524@hotmail.com
// Created 1/25/2023

namespace MyAnimangaAppLibrary.DataAccess
{
    public class MongoUserData
    {
        private readonly IMongoCollection<UserModel> _users;
        
        public MongoUserData(IDbConnection db)
        {
            _users = db.UserCollection;
            
        }
    }
}


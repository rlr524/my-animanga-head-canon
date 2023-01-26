// MongoUserData.cs
// robranf | rlr524@hotmail.com
// Created 1/23/2023

using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MyAnimangaAppLibrary.DataAccess;

public class DbConnection : IDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;
    private const string ConnectionId = "MongoDB";

    public string DbName { get; private set; }
    public string CategoryCollectionName { get; private set; } = "categories";
    public string StatusCollectionName { get; private set; } = "statuses";
    public string SuggestionCollectionName { get; private set; } = "suggestions";
    public string UserCollectionName { get; private set; } = "users";
    public string SourceCollectionName { get; private set; } = "sources";

    public MongoClient Client { get; private set; }
    public IMongoCollection<CategoryModel> CategoryCollection { get; private set; }
    public IMongoCollection<StatusModel> StatusCollection { get; private set; }
    public IMongoCollection<SuggestionModel> SuggestionCollection { get; private set; }
    public IMongoCollection<UserModel> UserCollection { get; private set; }
    public IMongoCollection<SourceModel> SourceCollection { get; private set; }

    public DbConnection(IConfiguration config)
    {
        _config = config;
        Client = new MongoClient(_config.GetConnectionString(ConnectionId));
        DbName = _config["DatabaseName"];
        _db = Client.GetDatabase(DbName);

        CategoryCollection = _db.GetCollection<CategoryModel>(CategoryCollectionName);
        StatusCollection = _db.GetCollection<StatusModel>(StatusCollectionName);
        SuggestionCollection = _db.GetCollection<SuggestionModel>(SuggestionCollectionName);
        UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
        SourceCollection = _db.GetCollection<SourceModel>(SourceCollectionName);
    }
}
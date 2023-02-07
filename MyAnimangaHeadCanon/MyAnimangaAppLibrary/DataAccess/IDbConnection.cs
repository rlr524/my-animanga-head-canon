// MyAnimangaHeadCanon
// MyAnimangaAppLibrary
// IDbConnection.cs
// Created: 01 26 2023
// Author: Rob Ranf (robranf)
// (C) 2023 Emiya Consulting, LLC

namespace MyAnimangaAppLibrary.DataAccess;

public interface IDbConnection
{
    string DbName { get; }
    string CategoryCollectionName { get; }
    string StatusCollectionName { get; }
    string SuggestionCollectionName { get; }
    string UserCollectionName { get; }
    string SourceCollectionName { get; }
    MongoClient Client { get; }
    IMongoCollection<CategoryModel> CategoryCollection { get; }
    IMongoCollection<StatusModel> StatusCollection { get; }
    IMongoCollection<SuggestionModel> SuggestionCollection { get; }
    IMongoCollection<UserModel> UserCollection { get; }
    IMongoCollection<SourceModel> SourceCollection { get; }
}
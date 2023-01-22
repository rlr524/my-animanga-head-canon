// MyAnimangaHeadCanon
// MyAnimangaAppLibrary
// SourceModel.cs
// Created: 01 22 2023
// Author: Rob Ranf (robranf)
// (C) 2023 Emiya Consulting, LLC

namespace MyAnimangaAppLibrary.Models;

public class SourceModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string SourceName { get; set; }
    public string SourceDescriptionShort { get; set; }
    public string SourceType { get; set; }
    public HashSet<string> UserFavorites { get; set; }
}
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
    public string SourcePublicationYear { get; set; }
    public string SourceStudio { get; set; }
    public string SourcePublisher { get; set; }
    public string SourceSeasons { get; set; }
    public string SourceVolumes { get; set; }
    public string SourceDescriptionLong { get; set; }
    public List<BasicSuggestionModel> SourceSuggestions { get; set; } = new();
    public HashSet<string> UserFavorites { get; set; } = new();
}
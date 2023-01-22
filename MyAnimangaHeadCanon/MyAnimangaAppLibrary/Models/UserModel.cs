// MyAnimangaHeadCanon
// MyAnimangaAppLibrary
// UserModel.cs
// Created: 01 22 2023
// Author: Rob Ranf (robranf)
// (C) 2023 Emiya Consulting, LLC
namespace MyAnimangaAppLibrary.Models;

public class UserModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string ObjectIdentifier { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }
    public string EmailAddress { get; set; }
    public List<BasicSuggestionModel> AuthoredSuggestions { get; set; } = new();
    public List<BasicSuggestionModel> VotedOnSuggestions { get; set; } = new();
    public List<BasicSuggestionModel> FlaggedSuggestions { get; set; } = new();
    public List<SourceModel> FavoriteSources { get; set; } = new();
}
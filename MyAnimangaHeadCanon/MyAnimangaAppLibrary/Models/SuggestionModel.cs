// MyAnimangaHeadCanon
// MyAnimangaAppLibrary
// SuggestionModel.cs
// Created: 01 22 2023
// Author: Rob Ranf (robranf)
// (C) 2023 Emiya Consulting, LLC

namespace MyAnimangaAppLibrary.Models;

public class SuggestionModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string SuggestionName { get; set; }
    public string SuggestionDescription { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public CategoryModel Category { get; set; }
    public BasicUserModel Author { get; set; }
    // A HashSet is a List that must have unique values
    // Using it here as don't want a user to be able to vote more than once
    public HashSet<string> UserVotes { get; set; } = new();
    // Used for users to flag as violation of community guidelines or as repeat suggestions
    public HashSet<string> UserFlags { get; set; } = new();
    public StatusModel SuggestionStatus { get; set; }
    public string OwnerNotes { get; set; }
    public bool TopVoteGetter { get; set; } = false;
}
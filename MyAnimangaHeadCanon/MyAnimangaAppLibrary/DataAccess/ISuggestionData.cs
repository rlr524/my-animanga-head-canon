// MyAnimangaHeadCanon
// MyAnimangaAppLibrary
// ISuggestionData.cs
// Created: 03 25 2023
// Author: Rob Ranf (robranf)
// (C) 2023 Emiya Consulting, LLC

namespace MyAnimangaAppLibrary.DataAccess;

public interface ISuggestionData
{
    Task<List<SuggestionModel>> GetAllSuggestions();
    Task<List<SuggestionModel>> GetAllApprovedSuggestions();
    Task<SuggestionModel> GetSuggestion(string id);
    Task<List<SuggestionModel>> GetAllTopVoteGetters();
    Task UpdateSuggestion(SuggestionModel suggestion);
    Task UpvoteSuggestion(string suggestionId, string userId);
    Task CreateSuggestion(SuggestionModel suggestion);
}
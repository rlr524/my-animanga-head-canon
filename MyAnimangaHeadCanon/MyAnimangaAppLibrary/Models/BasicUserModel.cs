// MyAnimangaHeadCanon
// MyAnimangaAppLibrary
// BasicUserModel.cs
// Created: 01 22 2023
// Author: Rob Ranf (robranf)
// (C) 2023 Emiya Consulting, LLC

/*
 * Basic models are sub-models stored under core models, they are not stored in a collection of their own.
 * The BasicUserModel is stored as a sub-model of SuggestionModel.
 */

namespace MyAnimangaAppLibrary.Models;

public class BasicUserModel
{
    private string Id { get; set; }
    private string DisplayName { get; set; }

    public BasicUserModel()
    {
            
    }

    public BasicUserModel(UserModel user)
    {
        Id = user.Id;
        DisplayName = user.DisplayName;
    }
}

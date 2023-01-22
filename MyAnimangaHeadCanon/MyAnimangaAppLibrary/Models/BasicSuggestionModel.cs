// MyAnimangaHeadCanon
// MyAnimangaAppLibrary
// BasicSuggestionModel.cs
// Created: 01 22 2023
// Author: Rob Ranf (robranf)
// (C) 2023 Emiya Consulting, LLC

/*
 * Basic models are sub-models stored under core models, they are not stored in a collection of their own.
 * The BasicSuggestionModel is stored as a sub-model of UserModel.
 */

namespace MyAnimangaAppLibrary.Models;

public class BasicSuggestionModel
{
    [BsonRepresentation(BsonType.ObjectId)]
    private string Id { get; set; }
    private string Suggestion { get; set; }

    // When you create an explicit constructor as below with BasicSuggestionModel(SuggestionModel suggestion)
    // it gets rid of the implicit constructor that comes with the class. Because of that, create a blank
    // explicit constructor here to still allow the use of new() in the UserModel when using this
    // BasicSuggestionModel.
    public BasicSuggestionModel()
    {
            
    }

    public BasicSuggestionModel(SuggestionModel suggestion)
    {
        Id = suggestion.Id;
        Suggestion = suggestion.SuggestionName;
    }
}
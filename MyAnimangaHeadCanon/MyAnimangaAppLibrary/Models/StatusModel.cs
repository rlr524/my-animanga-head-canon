// MyAnimangaHeadCanon
// MyAnimangaAppLibrary
// StatusModel.cs
// Created: 01 21 2023
// Author: Rob Ranf (robranf)
// (C) 2023 Emiya Consulting, LLC

namespace MyAnimangaAppLibrary.Models;

public class StatusModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string StatusName { get; set; }
    public string StatusDescription { get; set; }
}
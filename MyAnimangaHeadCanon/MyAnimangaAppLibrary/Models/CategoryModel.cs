﻿// MyAnimangaHeadCanon
// MyAnimangaAppLibrary
// CategoryModel.cs
// Created: 01 21 2023
// Author: Rob Ranf (robranf)
// (C) 2023 Emiya Consulting, LLC

namespace MyAnimangaAppLibrary.Models;
public class CategoryModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string CategoryName { get; set; }
    public string  CategoryDescription{ get; set; }
}

using MongoDB.Bson.Serialization.Attributes;

namespace MyAnimangaAppLibrary.Models;
internal class CategoryModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string  CategoryDescription{ get; set; }

}

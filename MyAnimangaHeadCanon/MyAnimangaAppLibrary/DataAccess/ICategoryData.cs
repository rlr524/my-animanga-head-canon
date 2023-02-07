/** 
* MongoCategoryData.cs
* Interface for controllers library for Category collection
* rlr52 | rob@emiyaconsulting.com
* net6.0
* Created 2/7/2023 2:31:36 PM
*/

namespace MyAnimangaAppLibrary.DataAccess;

public interface ICategoryData
{
    Task CreateCategory(CategoryModel category);
    Task<List<CategoryModel>> GetAllCategories();
}
/* 
* MongoCategoryData.cs
* Controllers library for Category collection
* rlr52 | rob@emiyaconsulting.com
* net6.0
* Created 2/7/2023 2:31:36 PM
*/

using Microsoft.Extensions.Caching.Memory;

namespace MyAnimangaAppLibrary.DataAccess;
public class MongoCategoryData : ICategoryData
{
    private readonly IMongoCollection<CategoryModel> _categories;
    private readonly IMemoryCache _cache;
    private const string CacheName = "CategoryData";

    public MongoCategoryData(IDbConnection db, IMemoryCache cache)
    {
        _cache = cache;
        _categories = db.CategoryCollection;
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        var output = _cache.Get<List<CategoryModel>>(CacheName);
        if (output is null)
        {
            var results = await _categories.FindAsync(_ => true);
            output = results.ToList();

            _cache.Set(CacheName, output, Globals.OneDay);
        }

        return output;
    }

    public Task CreateCategory(CategoryModel category)
    {
        return _categories.InsertOneAsync(category);
    }
}

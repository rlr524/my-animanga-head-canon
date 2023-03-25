namespace MyAnimangaHeadCanonUI;

public static class RegisterServices
{
    // The "this" keyword identifies this as an extension method
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        // Caching is built into web (Blazor) projects, so it's added here with simply a service registration.
        // It isn't added for any other projects, so we needed to add a caching NuGet package to the class library.
        builder.Services.AddMemoryCache();

        builder.Services.AddSingleton<IDbConnection, DbConnection>();
        builder.Services.AddSingleton<ICategoryData, MongoCategoryData>();
        builder.Services.AddSingleton<IStatusData, MongoStatusData>();
        builder.Services.AddSingleton<ISuggestionData, MongoSuggestionData>();
        builder.Services.AddSingleton<IUserData, MongoUserData>();
        builder.Services.AddSingleton<ISourceData, MongoSourceData>();
    }
}
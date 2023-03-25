// MyAnimangaHeadCanon
// MyAnimangaAppLibrary
// Globals.cs
// Created: 03 23 2023
// Author: Rob Ranf (robranf)
// (C) 2023 Emiya Consulting, LLC

namespace MyAnimangaAppLibrary;

public struct Globals
{
    public static readonly DateTime Now = DateTime.Now;
    public static readonly TimeSpan OneMinute = TimeSpan.FromMinutes(1);
    public static readonly TimeSpan OneDay = TimeSpan.FromDays(1);
    private const string DevFolder = @"/Users/robranf/Developer/DotNetProjects/my-animanga-head-canon/";
    private const string ProdFolder = @"D:\logs\";
    private const string FileName = "animangaHeadCanonLog.txt";
    private static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    private const string DevLogPath = DevFolder + FileName;
    private const string ProdLogPath = ProdFolder + FileName;
    public static readonly string LogPath = Env == "Development" ? DevLogPath : ProdLogPath;
}
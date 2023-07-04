using System.Reflection;
using Diploma_Zayats.Models;
using Diploma_Zayats.Models.Enums;
using Microsoft.Extensions.Configuration;

namespace Diploma_Zayats.Utilities.Configuration;

public static class Configurator
{
    private static readonly Lazy<IConfiguration> s_configuration;
    public static IConfiguration Configuration => s_configuration.Value;

    static Configurator()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath ?? throw new InvalidOperationException())
            .AddJsonFile("appsettings.json");

        var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "appsettings.*.json");

        foreach (var appSettingFile in appSettingFiles)
        {
            builder.AddJsonFile(appSettingFile);
        }

        return builder.Build();
    }

    public static AppSettings AppSettings
    {
        get
        {
            var appSettings = new AppSettings();
            var child = Configuration.GetSection("AppSettings");

            appSettings.URL = child["URL"];
            appSettings.MaxTimeout = int.Parse(child["MaxTimeout"]);
            appSettings.MaxWaitTime = int.Parse(child["MaxWaitTime"]);
            appSettings.WaitForPageLoadingTime = int.Parse(child["WaitForPageLoadingTime"]);
            appSettings.WebDriverWaitTime = int.Parse(child["WebDriverWaitTime"]);
            //appSettings.Headless = bool.Parse(child["Headless"]);

            return appSettings;
        }
    }

    public static List<User?> Users
    {
        get
        {
            List<User?> users = new List<User?>();
            var child = Configuration.GetSection("Users");
            foreach (var section in child.GetChildren())
            {
                var user = new User
                {
                    Token = section["Token"],
                    Username = section["Username"],
                    Password = section["Password"],
                    UserType = GetUserType(section["UserType"])
                };

                users.Add(user);
            }

            return users;
        }
    }

    public static User? Admin => Users.Find(x => x?.UserType == UserType.Admin);

    public static User UserWithInvalidPassword => Users.Find(x => x.UserType == UserType.UserWithInvalidPassword);

    public static User? UserByUsername(string username) => Users.Find(x => x?.Username == username);

    public static string? BrowserType => Configuration[nameof(BrowserType)];

    //public static bool Headless => bool.Parse(Configuration[nameof(Headless)]);

    private static UserType GetUserType(string userType)
    {
        return userType.ToLower() switch
        {
            "admin" => UserType.Admin,
            "user" => UserType.User,
            "userwithinvalidpassword" => UserType.UserWithInvalidPassword,
            _ => UserType.Admin
        };
    }
}
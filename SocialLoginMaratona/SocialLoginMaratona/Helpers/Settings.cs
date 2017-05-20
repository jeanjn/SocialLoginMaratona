// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SocialLoginMaratona.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        public static ISettings AppSettings => CrossSettings.Current;

        const string UserIdKey = "userid";
        static readonly string UserIdDefault = string.Empty;

        const string AuthTokenKey = "authtoken";
        static string AuthTokenDefault = string.Empty;

        public static string AuthToken
        {
            get => AppSettings.GetValueOrDefault(AuthTokenKey, AuthTokenDefault);
            set => AppSettings.AddOrUpdateValue(AuthTokenKey, value);
        }

        public static string UserId
        {
            get => AppSettings.GetValueOrDefault(UserIdKey, AuthTokenDefault);
            set => AppSettings.AddOrUpdateValue(UserIdKey, value);
        }

        public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserId);
    }
}
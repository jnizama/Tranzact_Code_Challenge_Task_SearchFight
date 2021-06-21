namespace SearchFight.Services.Models.Config
{
    public class GoogleConfig : BaseConfig
    {
        public static string BaseUrl => GetFromConfiguration("UrlGoogle");
        public static string ApiKey => GetFromConfiguration("UrlGoogleApiKey");
        public static string ContextId => GetFromConfiguration("UrlGoogleApiKeyContext");        
    }
}
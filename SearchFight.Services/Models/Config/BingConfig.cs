namespace SearchFight.Services.Models.Config
{
    public class BingConfig : BaseConfig
    {
        public static string BaseUrl => GetFromConfiguration("UrlBing");
        public static string ApiKey => GetFromConfiguration("UrlBingApiKey");        
    }
}
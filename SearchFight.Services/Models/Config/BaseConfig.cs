using System.Configuration;

namespace SearchFight.Services.Models.Config
{
    public class BaseConfig
    {
        private const string ErrorConfiguration = "There was an isue with the configuration file. (Missing Value: {Key})";

        public static string GetFromConfiguration(string key)
        {
            string configurationValue = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(configurationValue))
                throw new ConfigurationErrorsException(ErrorConfiguration.Replace("{Key}", key));

            return configurationValue;
        }
    }
}

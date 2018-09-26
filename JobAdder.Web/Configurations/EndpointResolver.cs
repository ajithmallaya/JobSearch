using System.Configuration;

namespace JobAdder.Web.Configurations
{
    interface IEndPointResolver
    {
        string BaseAddress { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }

    public class EndPointResolver : IEndPointResolver
    {
        public string BaseAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public EndPointResolver(string configurationKey)
        {
            var configurationString = ConfigurationManager.AppSettings[configurationKey];
            if (configurationString == null)
            {
                throw new ConfigurationErrorsException(
                    string.Format(
                        "An appSetting with the name '{0}' could not be found.",
                        configurationKey));
            }

            BaseAddress = configurationString;
        }
    }
}
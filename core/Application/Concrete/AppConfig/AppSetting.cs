using Application.Abstraction.AppConfig;
using Microsoft.Extensions.Configuration;

namespace Application.Concrete.AppConfig
{
    public class AppSetting : IAppSetting
    {
        private readonly IConfiguration _config;

        public AppSetting(IConfiguration config)
        {
            _config = config;
        }
        public string SqlConnectionString => Setting<string>("ConnectionStrings.DefaultSql");

        public string MongoDatabase => Setting<string>("Mongo.Database.Name");
        public string CloudConnectionString => Setting<string>("AzureCredentials.ConnectionString");
        public string CloudStorageUrl => Setting<string>("AzureCredentials.StorageUrl");
        public string FileContainer => Setting<string>("AzureCredentials.FileContainer");
        public string HashKey => Setting<string>("JWTKey.Key");

        private T Setting<T>(string name)
        {
            var configValue = name.Split(".");
            IConfigurationSection configurationSection = null;
            configurationSection = _config.GetSection(configValue[0]);
            for (int i = 1; i < configValue.Length; i++)
            {
                configurationSection = GetCustomSection(configurationSection, configValue[i]);
            }
            string value = configurationSection.Value;

            if (value == null)
            {
                throw new KeyNotFoundException(string.Format("Could not find setting '{0}',", name));
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

        private IConfigurationSection GetCustomSection(IConfigurationSection section, string value)
        {
            return section.GetSection(value);
        }
    }
}

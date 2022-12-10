using Microsoft.Extensions.Configuration;

namespace ECommerce.Persistence
{
    internal static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configuration = new();
                configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerce.API"));
                configuration.AddJsonFile("appsettings.json");

                return configuration.GetConnectionString("PostgreSql");
            }
        }
    }
}

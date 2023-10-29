using Microsoft.Extensions.Configuration;

namespace DataLib
{
    public class DBClient
    {
        public static string DBclient(string connectionstring)
        {
            var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
            return configuration.GetConnectionString(connectionstring);
        }
    }
}

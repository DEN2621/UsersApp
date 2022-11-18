using Microsoft.Extensions.Configuration;

namespace UsersWeb
{
    public class UsersConfiguration : IUsersConfiguration
    {
        private readonly IConfiguration configuration;
        public string APIBaseURL
        {
            get
            {
                return configuration.GetValue<string>("APIBaseURL");
            }
        }
        public UsersConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}

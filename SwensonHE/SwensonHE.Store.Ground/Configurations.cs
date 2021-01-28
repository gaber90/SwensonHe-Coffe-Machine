using Microsoft.Extensions.Configuration;

namespace SwensonHE.Store.Ground
{
    public static class Configurations
    {
        public static IConfiguration ConfigurationManager { get; set; }
       
        static string _CofeeStoreConnectionString;
        public static string CoffeeStoreConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_CofeeStoreConnectionString))
                    _CofeeStoreConnectionString = GetConnectionString("CoffeStoreConnectionString");
                    return _CofeeStoreConnectionString;
            }

        }

        static string GetConnectionString(string appSettingsKey)
        {
            var cs = ConfigurationManager.GetConnectionString(appSettingsKey);
            if (cs != null)
                return cs;

            return null;
        }
    }

}

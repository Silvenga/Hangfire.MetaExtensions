using Hangfire.MetaExtensions.Plugins;

namespace Hangfire.MetaExtensions
{
    public static class GlobalExtensions
    {
        public static IGlobalConfiguration UseMetaExtensions(this IGlobalConfiguration configuration)
        {
            configuration.UseFilter(new MetaClientFilterAttribute());
            configuration.UseFilter(new DynamicQueue());
            return configuration;
        }
    }
}
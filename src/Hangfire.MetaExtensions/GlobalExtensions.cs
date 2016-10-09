namespace Hangfire.MetaExtensions
{
    public static class GlobalExtensions
    {
        public static IGlobalConfiguration UseMetaExtensions(this IGlobalConfiguration configuration)
        {
            configuration.UseFilter(new MetaClientFilterAttribute());
            return configuration;
        }
    }
}
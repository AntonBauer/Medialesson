using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PicturesCompare.Cli
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCompareOptions(
            this IServiceCollection services,
            IConfiguration configuration) =>
            services.Configure<CompareOptions>(configuration.GetSection(CompareOptions.Section));
    }
}
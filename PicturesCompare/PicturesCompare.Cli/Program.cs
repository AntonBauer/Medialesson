using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PicturesCompare.Domain.Extensions;

namespace PicturesCompare.Cli
{
    internal static class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
                    services
                       .AddCompareOptions(context.Configuration)
                       .AddHostedService<PicturesComparison>()
                       .AddDomain(context.Configuration)
                );
    }
}
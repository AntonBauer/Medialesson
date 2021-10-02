using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PicturesCompare.Domain.Enums;
using PicturesCompare.Domain.HashServices;
using PicturesCompare.Domain.Options;
using PicturesCompare.Domain.PhotoComparisonServices;

namespace PicturesCompare.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration) =>
            services.AddTransient<IPhotoComparisonService, PhotoComparisonService>()
               .AddTransient<IHashService>(_ =>
                {
                    var options = configuration.GetSection(HashServiceOptions.Section).Get<HashServiceOptions>();
                    return options.HashType switch
                    {
                        HashType.Average => new AverageHashService(),
                        HashType.Perceptual => new PerceptualHashService(),
                        _ => throw new ArgumentOutOfRangeException(nameof(options.HashType), "Unknown hash type")
                    };
                });
    }
}
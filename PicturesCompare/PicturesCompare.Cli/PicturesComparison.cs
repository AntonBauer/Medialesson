using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PicturesCompare.Domain.PhotoComparisonServices;

namespace PicturesCompare.Cli
{
    internal sealed class PicturesComparison : IHostedService
    {
        private readonly IPhotoComparisonService _photoComparisonService;
        private readonly CompareOptions _compareOptions;

        public PicturesComparison(IPhotoComparisonService photoComparisonService, IOptions<CompareOptions> compareOptions)
        {
            _photoComparisonService = photoComparisonService;
            _compareOptions = compareOptions.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var arePicturesSame = await _photoComparisonService.CompareAsync(_compareOptions.ImageA, _compareOptions.ImageB);
            var message = arePicturesSame
                ? Messages.PicturesAreSame
                : Messages.PicturesAreNotSame;
            
            Console.WriteLine(message);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Comparison exited");
            return Task.CompletedTask;
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using PicturesCompare.Domain.PhotoComparisonServices;

namespace PicturesCompare.Cli
{
    internal sealed class PicturesComparison : IHostedService
    {
        private readonly IPhotoComparisonService _photoComparisonService;

        public PicturesComparison(IPhotoComparisonService photoComparisonService)
        {
            _photoComparisonService = photoComparisonService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var arePicturesSame = await _photoComparisonService.CompareAsync(string.Empty, string.Empty);
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
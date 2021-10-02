using System;
using System.IO;
using System.Threading.Tasks;
using PicturesCompare.Domain.Extensions;
using PicturesCompare.Domain.HashServices;

namespace PicturesCompare.Domain.PhotoComparisonServices
{
    internal sealed class PhotoComparisonService : IPhotoComparisonService
    {
        private readonly IHashService _hashService;

        public PhotoComparisonService(IHashService hashService)
        {
            _hashService = hashService;
        }

        public Task<bool> CompareAsync(string filePathImageA, string filePathImageB)
        {
            EnsureFilesExists(filePathImageA, filePathImageB);

            var imageAHash = filePathImageA.Load().CalculateHash(_hashService);
            var imageBHash = filePathImageB.Load().CalculateHash(_hashService);

            return Task.FromResult(imageAHash == imageBHash);
        }

        private static void EnsureFilesExists(string filePathImageA, string filePathImageB)
        {
            if (!File.Exists(filePathImageA))
                throw new ArgumentException("File A does not exists", nameof(filePathImageA));

            if (!File.Exists(filePathImageB))
                throw new ArgumentException("File B does not exists", nameof(filePathImageB));
        }
    }
}
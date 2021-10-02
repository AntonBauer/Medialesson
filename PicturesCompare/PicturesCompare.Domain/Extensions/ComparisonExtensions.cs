using System.IO;
using PicturesCompare.Domain.HashServices;
using SixLabors.ImageSharp;

namespace PicturesCompare.Domain.Extensions
{
    internal static class ComparisonExtensions
    {
        public static int CalculateHash(this Image image, IHashService hashService) =>
            hashService.CalculateHash(image);
    }
}
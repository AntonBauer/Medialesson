using System.IO;
using PicturesCompare.Domain.HashServices;

namespace PicturesCompare.Domain.Extensions
{
    internal static class ComparisonExtensions
    {
        public static string LoadImage(this string imagePath)
        {
            using var fileStream = File.OpenRead(imagePath);
            return imagePath;
        }
        
        public static int CalculateHash(this string image, IHashService hashService) =>
            hashService.CalculateHash(image);
    }
}
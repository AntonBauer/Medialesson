using PicturesCompare.Domain.HashServices;

namespace PicturesCompare.Domain.Extensions
{
    internal static class ComparisonExtensions
    {
        public static string LoadImage(this string imagePath) => imagePath;

        public static int CalculateHash(this string image, IHashService hashService) =>
            hashService.CalculateHash(image);
    }
}
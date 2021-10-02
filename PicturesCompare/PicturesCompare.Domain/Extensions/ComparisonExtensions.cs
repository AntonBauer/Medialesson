using PicturesCompare.Domain.HashServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PicturesCompare.Domain.Extensions
{
    internal static class ComparisonExtensions
    {
        public static int CalculateHash(this Image<Rgb24> image, IHashService hashService) =>
            hashService.CalculateHash(image);
    }
}
using PicturesCompare.Domain.Extensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PicturesCompare.Domain.HashServices
{
    internal sealed class AverageHashService : IHashService
    {
        public int CalculateHash(Image<Rgb24> image) =>
            image.ToGrayscale()
               .ScaleTo(8, 8)
               .CalcAverageHash();
    }
}
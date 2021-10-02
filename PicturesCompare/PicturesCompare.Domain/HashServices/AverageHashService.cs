using PicturesCompare.Domain.Extensions;
using SixLabors.ImageSharp;

namespace PicturesCompare.Domain.HashServices
{
    internal sealed class AverageHashService : IHashService
    {
        public int CalculateHash(Image image) =>
            image.ToGrayscale()
               .ScaleTo(8, 8)
               .CalcAverageHash();
    }
}
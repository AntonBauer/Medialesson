using PicturesCompare.Domain.Extensions;

namespace PicturesCompare.Domain.HashServices
{
    internal sealed class AverageHashService : IHashService
    {
        public int CalculateHash(string image) =>
            image.ToGrayscale()
               .ScaleTo(8, 8)
               .CalcAverageHash();
    }
}
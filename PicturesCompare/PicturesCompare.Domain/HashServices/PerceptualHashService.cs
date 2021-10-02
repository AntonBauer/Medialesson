using PicturesCompare.Domain.Extensions;

namespace PicturesCompare.Domain.HashServices
{
    internal sealed class PerceptualHashService : IHashService
    {
        public int CalculateHash(string image) =>
            image.ToGrayscale()
               .ScaleTo(32, 32)
               .ApplyDcsPerRows(32)
               .ApplyDcsPerColumns(32)
               .CropTo(8, 8)
               .CalcPerceptualHash();
    }
}
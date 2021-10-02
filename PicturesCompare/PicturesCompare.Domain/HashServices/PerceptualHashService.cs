using PicturesCompare.Domain.Extensions;
using SixLabors.ImageSharp;

namespace PicturesCompare.Domain.HashServices
{
    internal sealed class PerceptualHashService : IHashService
    {
        public int CalculateHash(Image image) =>
            image.ToGrayscale()
               .ScaleTo(32, 32)
               .ApplyDcsPerRows()
               .ApplyDcsPerColumns()
               .CropTo(8, 8)
               .CalcPerceptualHash();
    }
}
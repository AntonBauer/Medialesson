using PicturesCompare.Domain.Extensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PicturesCompare.Domain.HashServices
{
    internal sealed class PerceptualHashService : IHashService
    {
        public int CalculateHash(Image<Rgb24> image) =>
            image.ToGrayscale()
               .ScaleTo(32, 32)
               .ApplyDcsPerRows()
               .ApplyDcsPerColumns()
               .CropTo(8, 8)
               .CalcPerceptualHash();
    }
}
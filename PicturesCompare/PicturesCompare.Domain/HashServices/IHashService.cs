using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PicturesCompare.Domain.HashServices
{
    internal interface IHashService
    {
        int CalculateHash(Image<Rgb24> image);
    }
}
using SixLabors.ImageSharp;

namespace PicturesCompare.Domain.HashServices
{
    internal interface IHashService
    {
        int CalculateHash(Image image);
    }
}
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace PicturesCompare.Domain.Extensions
{
    internal static class ImageExtensions
    {
        public static Image Load(this string imagePath) => Image.Load(imagePath);

        public static Image ToGrayscale(this Image image)
        {
            image.Mutate(ctx => ctx.Grayscale());
            return image;
        }

        public static Image ScaleTo(this Image image, int width, int height)
        {
            image.Mutate(ctx => ctx.Resize(width, height));
            return image;
        }

        public static Image CropTo(this Image image, int width, int height)
        {
            image.Mutate(ctx => ctx.Crop(width, height));
            return image;
        }
    }
}
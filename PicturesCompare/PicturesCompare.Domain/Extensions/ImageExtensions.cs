using PicturesCompare.Domain.HashServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace PicturesCompare.Domain.Extensions
{
    internal static class ImageExtensions
    {
        public static Image<Rgb24> Load(this string imagePath) => Image.Load<Rgb24>(imagePath);
        
        public static int CalculateHash(this Image<Rgb24> image, IHashService hashService) =>
            hashService.CalculateHash(image);

        public static Image<Rgb24> ToGrayscale(this Image<Rgb24> image)
        {
            image.Mutate(ctx => ctx.Grayscale());
            return image;
        }

        public static Image<Rgb24> ScaleTo(this Image<Rgb24> image, int width, int height)
        {
            image.Mutate(ctx => ctx.Resize(width, height));
            return image;
        }

        public static Image<Rgb24> CropTo(this Image<Rgb24> image, int width, int height)
        {
            image.Mutate(ctx => ctx.Crop(width, height));
            return image;
        }

        public static byte[] ToByteArray(this Image<Rgb24> image)
        {
            // Prerequisite - image is grayscale
            var bytes = new byte[image.Width * image.Height];
            
            for (var i = 0; i < image.Width; i++)
            {
                for (var j = 0; j < image.Height; j++)
                {
                    bytes[image.Width * i + j] = image[i, j].B;
                }
            }

            return bytes;
        }
    }
}
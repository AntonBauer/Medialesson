using System;
using System.Linq;

namespace PicturesCompare.Domain.Extensions
{
    internal static class ImageExtensions
    {
        // ToDo: implement image operations
        public static byte[] ToGrayscale(this string image) => Array.Empty<byte>();

        public static byte[] ScaleTo(this byte[] image, int width, int height) =>
            Enumerable.Repeat((byte)0, width * height)
               .ToArray();

        public static byte[] CropTo(this byte[] image, int width, int height) =>
            Enumerable.Repeat((byte)0, width * height)
               .ToArray();
    }
}
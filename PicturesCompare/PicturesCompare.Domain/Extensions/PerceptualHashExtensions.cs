using System;
using System.Collections.Generic;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PicturesCompare.Domain.Extensions
{
    internal static class PerceptualHashExtensions
    {
        public static Image<Rgb24> ApplyDcsPerRows(this Image<Rgb24> image) => image;

        public static Image<Rgb24> ApplyDcsPerColumns(this Image<Rgb24> image) => image;

        public static void ApplyDcs()
        {
            
        }

        public static int CalcPerceptualHash(this Image<Rgb24> image)
        {
            var median = image.Median();
            
            var hashBytes = image.ToByteArray().Aggregate(
                new List<byte>(image.Height * image.Width),
                (acc, pixel) =>
                {
                    acc.Add((byte)Math.Sign(pixel - median));
                    return acc;
                }).ToArray();

            return BitConverter.ToInt32(hashBytes);
        }

        private static int Median(this Image<Rgb24> image)
        {
            var imageBytes = image.ToByteArray();
            var sortedValues = imageBytes.OrderBy(v => v).ToArray();

            var isEven = sortedValues.Length % 2 == 0;
            var middleIndex = sortedValues.Length / 2;
            return isEven
                ? (sortedValues[middleIndex] + sortedValues[middleIndex + 1]) / 2
                : sortedValues[middleIndex + 1];
        }
    }
}
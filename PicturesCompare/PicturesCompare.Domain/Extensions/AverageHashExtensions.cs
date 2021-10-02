using System;
using System.Collections.Generic;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PicturesCompare.Domain.Extensions
{
    internal static class AverageHashExtensions
    {
        public static int CalcAverageHash(this Image<Rgb24> image)
        {
            var average = image.Average();
            
            var hashBytes = image.ToByteArray().Aggregate(
                new List<byte>(image.Width * image.Height),
                (acc, pixel) =>
                {
                    acc.Add((byte)Math.Sign(pixel - average));
                    return acc;
                }).ToArray();

            return BitConverter.ToInt32(hashBytes);
        }

        private static int Average(this Image<Rgb24> image) =>
             image.ToByteArray().Select(b => (int)b).Sum() / (image.Width * image.Height);   
    }
}
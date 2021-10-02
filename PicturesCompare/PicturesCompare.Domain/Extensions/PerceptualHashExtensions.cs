using System;
using System.Collections.Generic;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace PicturesCompare.Domain.Extensions
{
    internal static class PerceptualHashExtensions
    {
        // https://content-blockchain.org/research/testing-different-image-hash-functions/
        // Perceptual Hash
        public static Image<Rgb24> ApplyDcsPerRows(this Image<Rgb24> image)
        {
            image.Mutate(ctx => ctx.ProcessPixelRowsAsVector4(row =>
            {
                // ReSharper disable InconsistentNaming
                var N = row.Length;
                // ReSharper restore InconsistentNaming
                
                for (var i = 0; i < row.Length; i++)
                {
                    var k = i;
                    var value = (float)Enumerable
                       .Range(0, row.Length - 1)
                       .Sum(n => 2 * n * Math.Cos(Math.PI * k * (2 * n + 1) / N));
                    row[i].W = value;
                    row[i].X = value;
                    row[i].Y = value;
                    row[i].Z = value;
                }
            }));
            
            return image;
        }

        public static Image<Rgb24> ApplyDcsPerColumns(this Image<Rgb24> image)
        {
            image.Mutate(ctx => ctx.Rotate(RotateMode.Rotate90));
            image = image.ApplyDcsPerRows();
            image.Mutate(ctx => ctx.Rotate(RotateMode.Rotate270));
            
            return image;
        }

        public static int CalcPerceptualHash(this Image<Rgb24> image)
        {
            var imageBytes = image.ToByteArray();
            var median = imageBytes.Median();
            
            var hashBytes = imageBytes.Aggregate(
                new List<byte>(image.Height * image.Width),
                (acc, pixel) =>
                {
                    acc.Add((byte)Math.Sign(pixel - median));
                    return acc;
                }).ToArray();

            return BitConverter.ToInt32(hashBytes);
        }

        private static int Median(this byte[] imageBytes)
        {
            var sortedValues = imageBytes.OrderBy(v => v).ToArray();

            var isEven = sortedValues.Length % 2 == 0;
            var middleIndex = sortedValues.Length / 2;
            return isEven
                ? (sortedValues[middleIndex] + sortedValues[middleIndex + 1]) / 2
                : sortedValues[middleIndex + 1];
        }
    }
}
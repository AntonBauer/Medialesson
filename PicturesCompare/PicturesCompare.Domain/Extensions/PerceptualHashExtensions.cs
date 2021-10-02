using System;
using System.Collections.Generic;
using System.Linq;

namespace PicturesCompare.Domain.Extensions
{
    internal static class PerceptualHashExtensions
    {
        public static byte[] ApplyDcsPerRows(this byte[] image, int rowLength) => image;

        public static byte[] ApplyDcsPerColumns(this byte[] image, int columnLength) => image;

        public static int CalcPerceptualHash(this byte[] image)
        {
            var median = image.Median();
            
            var hashBytes = image.Aggregate(
                new List<byte>(image.Length),
                (acc, pixel) =>
                {
                    acc.Add((byte)Math.Sign(pixel - median));
                    return acc;
                }).ToArray();

            return BitConverter.ToInt32(hashBytes);
        }

        private static int Median(this byte[] image)
        {
            var sortedValues = image.OrderBy(v => v).ToArray();

            var isEven = sortedValues.Length % 2 == 0;
            var middleIndex = sortedValues.Length / 2;
            return isEven
                ? (sortedValues[middleIndex] + sortedValues[middleIndex + 1]) / 2
                : sortedValues[middleIndex + 1];
        }
    }
}
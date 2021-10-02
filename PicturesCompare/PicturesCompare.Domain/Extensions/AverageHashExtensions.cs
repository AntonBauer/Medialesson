﻿using System;
using System.Collections.Generic;
using System.Linq;
using SixLabors.ImageSharp;

namespace PicturesCompare.Domain.Extensions
{
    internal static class AverageHashExtensions
    {
        public static int CalcAverageHash(this Image image)
        {
            var average = image.Average();
            
            var hashBytes = image.Aggregate(
                new List<byte>(image.Length),
                (acc, pixel) =>
                {
                    acc.Add((byte)Math.Sign(pixel - average));
                    return acc;
                }).ToArray();

            return BitConverter.ToInt32(hashBytes);
        }

        private static byte Average(this Image image) => (byte)(image.Select(b => (int)b).Sum() / image.Length);
    }
}
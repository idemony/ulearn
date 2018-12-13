using System.Collections;
using System;
using System.Collections.Generic;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            var lenX = original.GetLength(0);
            var lenY = original.GetLength(1);
            var allPixels = new List<double>();
            var t = 0.0;
            double whitePixelsCount;
            for (var x = 0; x <= 1; x++)
            {
                for (var i = 0; i < lenX; i++)
                    for (var j = 0; j < lenY; j++)
                    {
                        if (x == 0)
                            allPixels.Add(original[i, j]);
                        else
                        {
                            if (original[i, j] >= t)
                                original[i, j] = 1.0;
                            else
                                original[i, j] = 0.0;
                        }
                    }
                allPixels.Sort();
                var count = allPixels.Count;
                var n = original.Length;
                whitePixelsCount = (int)(n * whitePixelsFraction);
                if (whitePixelsCount == 0)
                    t = int.MaxValue;
                else
                {
                    var tIndex = (int)(count - whitePixelsCount);
                    t = allPixels[tIndex];
                }
            }
            return original;
        }
    }
}

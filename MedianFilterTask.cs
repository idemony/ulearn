using System.Linq;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		public static double[,] MedianFilter(double[,] original)
		{
            var lenX = original.GetLength(0);
            var lenY = original.GetLength(1);
            var newImage = new double[lenX, lenY];
            
            for (var i = 0; i < lenX; i++)
            {
                for (var j = 0; j < lenY; j++)
                {
                    var currentMedian = new List<double>();
                    for (var ii = -1; ii < 2; ii++)
                        for (var jj = -1; jj < 2; jj++)
                            if (i + ii >= 0 && j + jj >= 0 && i + ii < lenX && j + jj < lenY)
                                currentMedian.Add(original[i + ii, j + jj]);
                    currentMedian.Sort();
                    var count = currentMedian.Count;
                    if (count % 2 == 0)
                        newImage[i, j] = (currentMedian[count / 2] + currentMedian[(count / 2) - 1]) / 2;
                    else
                        newImage[i, j] = currentMedian[count / 2];
                }
            }
			return newImage;
		}
	}
}

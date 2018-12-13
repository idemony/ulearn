using System.Drawing;
using System;
using static System.Math;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
            double x = 1;
            double y = 0;
            double xNext = 0;
            double yNext = 0;
            var random = new Random(seed);
            for (int i = 0; i < iterationsCount; i++)
            {
                if (random.Next(2) == 0)
                {
                    xNext = (x * Cos(PI / 4) - y * Sin(PI / 4)) / Sqrt(2);
                    yNext = (x * Sin(PI / 4) + y * Cos(PI / 4)) / Sqrt(2);
                }
                else
                {
                    xNext = (x * Cos(3 * PI / 4) - y * Sin(3 * PI / 4)) / Sqrt(2) + 1;
                    yNext = (x * Sin(3 * PI / 4) + y * Cos(3 * PI / 4)) / Sqrt(2);
                }
                x = xNext;
                y = yNext;
                pixels.SetPixel(xNext, yNext);
            }
		}
	}
}

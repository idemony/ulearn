using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            var edge = sx.GetLength(0) / 2;
            var sy = MakeMatrixSy(sx);
            for (int x = edge; x < width - edge; x++)
                for (int y = edge; y < height - edge; y++)
                {
                    var gx = MultiplyGS(g, sx, x, y);
                    var gy = MultiplyGS(g, sy, x, y);
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }
        
        public static double[,] MakeMatrixSy(double[,] sx)
        {
            var lenX = sx.GetLength(0);
            var lenY = sx.GetLength(1);
            var sy = new double[lenX, lenY];
            for (var i = 0; i < lenX; i++)
                for (var j = 0; j < lenY; j++)
                    sy[i, j] = sx[j, i];
            return sy;
        }

        public static double MultiplyGS(double[,] g, double[,] s, int x, int y)
        {
            double gRes = 0;
            var edge = s.GetLength(0) / 2;
            var length = s.GetLength(0);
            for (var i = 0; i < length; i++)
                for (var j = 0; j < length; j++)
                    gRes += s[i, j] * g[x + i - edge, y + j - edge];
            return gRes;
        }
    }
}

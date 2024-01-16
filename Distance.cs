using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
            // Случай, когда длина отрезка равна нулю.
            if (ax == bx && ay == by)
                return Math.Sqrt((ax - x) * (ax - x) + (ay - y) * (ay - y));
            var squareDistanceOfSegment = (bx - ax) * (bx - ax) + (by - ay) * (by - ay);
            var t = ((x - ax) * (bx - ax) + (y - ay) * (by - ay)) / (squareDistanceOfSegment);
            if (t < 0)
                t = 0;
            else if (t > 1)
                t = 1;
            return Math.Sqrt(Math.Pow(ax - x + (bx - ax) * t, 2) + Math.Pow(ay - y + (by - ay) * t, 2));
		}
	}
}

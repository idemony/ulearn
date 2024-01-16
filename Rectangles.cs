using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
            return !(r1.Right < r2.Left || r1.Left > r2.Right || r1.Top > r2.Bottom || r1.Bottom < r2.Top);
		}

        public static int SquareOfSmallerRectangle(Rectangle r1, Rectangle r2)
        {
            if (IndexOfInnerRectangle(r1, r2) == 0)
                return (r1.Right - r1.Left) * (r1.Bottom - r1.Top);
            else
                return (r2.Right - r2.Left) * (r2.Bottom - r2.Top);
        }

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (AreIntersected(r1, r2))
            {
                if (IndexOfInnerRectangle(r1, r2) != -1)
                {
                    return SquareOfSmallerRectangle(r1, r2);
                }
                else
                {
                    var length = Math.Min(Math.Abs(r1.Right - r2.Left), Math.Abs(r1.Left - r2.Right));
                    var width = Math.Min(Math.Abs(r1.Top - r2.Bottom), Math.Abs(r1.Bottom - r2.Top));
                    if (r1.Left > r2.Left && r1.Right < r2.Right)
                        length = r1.Right - r1.Left;
                    if (r2.Left > r1.Left && r2.Right < r1.Right)
                        length = r2.Right - r2.Left;
                    if (r1.Top > r2.Top && r1.Bottom < r2.Bottom)
                        width = r1.Bottom - r1.Top;
                    if (r2.Top > r1.Top && r2.Bottom < r1.Bottom)
                        width = r2.Bottom - r2.Top;
                    return length * width;
                }
            }
            else
                return 0;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            if (r1.Top <= r2.Top && r1.Bottom >= r2.Bottom && r1.Right >= r2.Right && r1.Left <= r2.Left)
                return 1;
            if (r2.Top <= r1.Top && r2.Bottom >= r1.Bottom && r2.Right >= r1.Right && r2.Left <= r1.Left)
                return 0;
            return -1;
        }
	}
}

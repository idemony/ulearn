namespace Recognizer
{
	public static class GrayscaleTask
	{
		public static double[,] ToGrayscale(Pixel[,] original)
		{
            var lenX = original.GetLength(0);
            var lenY = original.GetLength(1);
            var grayscale = new double[original.GetLength(0), original.GetLength(1)];
            for (var i = 0; i < lenX; i++)
                for (var j = 0; j < lenY; j++)
                {
                    var red = original[i, j].R;
                    var green = original[i, j].G;
                    var blue = original[i, j].B;
                    grayscale[i, j] = (0.299 * red + 0.587 * green + 0.114 * blue) / 255;
                }
			return grayscale;   
		}
	}
}

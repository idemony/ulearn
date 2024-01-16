namespace Mazes
{
	public static class DiagonalMazeTask
	{
        public static void MoveDownHTimes(Robot robot, int h, int height)
        {
            for (int i = 0; i < h; i++)
                if (robot.Y < height - 2)
                    robot.MoveTo(Direction.Down);
        }

        public static void MoveRightWTimes(Robot robot, int w, int width)
        {
            for (int i = 0; i < w; i++)
                if (robot.X < width - 2)
                    robot.MoveTo(Direction.Right);
        }

        public static void MoveToNextSecondTurn(Robot robot, int width, int height, int w, int h)
        {
            if (width > height)
            {
                MoveRightWTimes(robot, w, width);
                MoveDownHTimes(robot, h, height);
            }
            else
            {
                MoveDownHTimes(robot, h, height);
                MoveRightWTimes(robot, w, width);
            }
        }

		public static void MoveOut(Robot robot, int width, int height)
		{
            var w = 1;
            var h = 1;
            if (width > height)
                w = (width - 2) / (height - 2);
            else h = (height - 2) / (width - 2);
            while (!(robot.X == width - 2 && robot.Y == height - 2))
                MoveToNextSecondTurn(robot, width, height, w, h);
		}
	}
}

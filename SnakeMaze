namespace Mazes
{
	public static class SnakeMazeTask
	{
        public static void MoveRightToEdge(Robot robot, int width)
        {
            for (int i = 0; i < width - 3; i++)
                robot.MoveTo(Direction.Right);
        }

        public static void MoveLeftToEdge(Robot robot, int width)
        {
            for (int i = 0; i < width - 3; i++)
                robot.MoveTo(Direction.Left);
        }

        public static void MoveDownTwoTimes(Robot robot)
        {
            robot.MoveTo(Direction.Down);
            robot.MoveTo(Direction.Down);
        }

        public static void MoveOut(Robot robot, int width, int height)
		{
            while (!(robot.X == 1 && robot.Y == height - 2))
            {
                MoveRightToEdge(robot, width);
                MoveDownTwoTimes(robot);
                MoveLeftToEdge(robot, width);
                if (robot.Y < height - 2)
                    MoveDownTwoTimes(robot);
            }
		}
	}
}

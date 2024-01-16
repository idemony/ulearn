using System;
namespace Mazes
{
	public static class EmptyMazeTask
	{
        public static void MoveRightIfPossible(Robot robot, int width)
        {
            for (int i = 0; i < width; i++)
                if (robot.X < width - 2)
                    robot.MoveTo(Direction.Right);
        }

        public static void MoveDownIfPossible(Robot robot, int height)
        {
            for (int i = 0; i < height; i++)
                if (robot.Y < height - 2)
                    robot.MoveTo(Direction.Down);
        }

		public static void MoveOut(Robot robot, int width, int height)
		{
            MoveDownIfPossible(robot, height);
            MoveRightIfPossible(robot, width);
		}
	}
}

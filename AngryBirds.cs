using System;

namespace AngryBirds
{
    public static class AngryBirdsTask
    {
        /// <param name="v">Начальная скорость</param>
        /// <param name="distance">Расстояние до цели</param>
        /// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
        public static double FindSightAngle(double v, double distance)
        {
            var g = 9.8;
            var angle = Math.Asin(g * distance / (v * v)) / 2;
            return angle;
        }
    }
}

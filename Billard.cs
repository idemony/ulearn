using System;

namespace Billiards
{
    public static class BilliardsTask
    {
		/// <summary>
        /// Все углы берутся относительно горизонтали против часовой стрелки.
        /// </summary>
        /// <param name="directionRadians">Угол направелния движения шара. </param>
        /// <param name="wallInclinationRadians">Угол стены. </param>
        /// <returns>Угол отскока шарика от стены. </returns>
        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {
            return (wallInclinationRadians - directionRadians) + wallInclinationRadians;
        }
    }
}

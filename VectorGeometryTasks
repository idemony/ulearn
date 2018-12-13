using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTasks
{
    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            var result = new Vector();
            result.X = vector1.X + vector2.X;
            result.Y = vector1.Y + vector2.Y;
            return result;
        }
    }

    public class Vector
    {
        public double X;
        public double Y;
    }
}

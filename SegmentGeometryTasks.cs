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

        public static double GetLength(Segment segment)
        {
            segment.End.X *= -1;
            segment.End.Y *= -1;
            var result = Add(segment.Begin, segment.End);
            return GetLength(result);
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            vector.X *= -1;
            vector.Y *= -1;
            var vectorToBegin = Add(segment.Begin, vector);
            var vectorToEnd = Add(segment.End, vector);
            return GetLength(segment) == (GetLength(vectorToBegin) + GetLength(vectorToEnd));
        }
    }

    public class Vector
    {
        public double X;
        public double Y;
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;
    }
}

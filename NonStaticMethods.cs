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

        public double GetLength()
        {
            var vector = new Vector();
            vector.X = X;
            vector.Y = Y;
            return Geometry.GetLength(vector);
        }

        public Vector Add(Vector vector2)
        {
            var vector1 = new Vector();
            vector1.X = X;
            vector1.Y = Y;
            return Geometry.Add(vector1, vector2);
        }

        public bool Belongs(Segment segment)
        {
            var vector = new Vector();
            vector.X = X;
            vector.Y = Y;
            return Geometry.IsVectorInSegment(vector, segment);
        }
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public double GetLength(Segment segment)
        {
            return Geometry.GetLength(segment);
        }

        public bool Contains(Vector vector)
        {
            var segment = new Segment();
            segment.Begin = Begin;
            segment.End = End;
            return Geometry.IsVectorInSegment(vector, segment);
        }
    }
}

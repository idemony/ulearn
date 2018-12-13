using System;
using static System.Math;
using NUnit.Framework;

namespace Manipulation
{
    public class TriangleTask
    {
        /// <summary>
        /// Возвращает угол (в радианах) между сторонами a и b в треугольнике со сторонами a, b, c 
        /// </summary>
        public static double GetABAngle(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
                return double.NaN;

            if (a + b < c || a + c < b || b + c < a)
                return double.NaN;

            var angle = Acos((a * a + b * b - c * c) / (2 * a * b));
            return angle;
        }
    }

    [TestFixture]
    public class TriangleTask_Tests
    {
        [TestCase(3, 4, 5, Math.PI / 2)]
        [TestCase(1, 1, 1, Math.PI / 3)]
        [TestCase(1, 3, 0, double.NaN)]
        [TestCase(-3, -5, -7, double.NaN)]
        [TestCase(5, 1, 7, double.NaN)]
        
        public void TestGetABAngle(double a, double b, double c, double expectedAngle)
        {
            var myAngle = TriangleTask.GetABAngle(a, b, c);
            if (myAngle == double.NaN || expectedAngle == double.NaN)
                Assert.AreEqual(myAngle, expectedAngle);
            else Assert.AreEqual(myAngle, expectedAngle, 1e-5);
        }
    }
}

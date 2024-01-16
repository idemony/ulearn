using System;
using System.Drawing;
using static System.Math;
using static Manipulation.Manipulator;
using NUnit.Framework;

namespace Manipulation
{
    public static class AnglesToCoordinatesTask
    {
        /// <summary>
        /// По значению углов суставов возвращает массив координат суставов
        /// в порядке new []{elbow, wrist, palmEnd}
        /// </summary>
        public static PointF[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            var elbowX = UpperArm * Cos(shoulder);
            var elbowY = UpperArm * Sin(shoulder);
            var elbowPos = new PointF((float) elbowX, (float) elbowY);

            var angle2 = elbow + shoulder - PI;
            var wristX = Forearm * Cos(angle2) + elbowX;
            var wristY = Forearm * Sin(angle2) + elbowY;
            var wristPos = new PointF((float) wristX, (float) wristY);

            var angle3 = wrist + angle2 - PI;
            var palmX = Palm * Cos(angle3) + wristX;
            var palmY = Palm * Sin(angle3) + wristY;
            var palmEndPos = new PointF((float) palmX, (float) palmY);
            return new PointF[]
            {
                elbowPos,
                wristPos,
                palmEndPos
            };
        }
    }

    [TestFixture]
    public class AnglesToCoordinatesTask_Tests
    {
        [TestCase(PI / 2, PI / 2, PI, Forearm + Palm, UpperArm)]
        [TestCase(PI / 2, PI / 2, PI / 2, Forearm, UpperArm - Palm)]
        [TestCase(PI / 2, 3 * PI / 2, 3 * PI / 2, - Forearm, UpperArm - Palm)]
        [TestCase(PI / 2, PI, 3 * PI, 0, Forearm + UpperArm + Palm)]

        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            Assert.AreEqual(palmEndX, joints[2].X, 1e-5, "palm endX");
            Assert.AreEqual(palmEndY, joints[2].Y, 1e-5, "palm endY");
            Assert.AreEqual(GetDistance(joints[0], new PointF(0, 0)), UpperArm);
            Assert.AreEqual(GetDistance(joints[0], joints[1]), Forearm);
            Assert.AreEqual(GetDistance(joints[1], joints[2]), Palm);
        }

        public double GetDistance(PointF point1, PointF point2)
        {
            var differenceX = (point1.X - point2.X) * (point1.X - point2.X);
            var differenceY = (point1.Y - point2.Y) * (point1.Y - point2.Y);
            return Sqrt(differenceX + differenceY);
        }
    }
}

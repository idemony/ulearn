using NUnit.Framework;
using static System.Math;
using static Manipulation.Manipulator;
using static Manipulation.TriangleTask;
using System;

namespace Manipulation
{
    public static class ManipulatorTask
    {
        /// <summary>
        /// Возвращает массив углов (shoulder, elbow, wrist),
        /// необходимых для приведения эффектора манипулятора в точку x и y 
        /// с углом между последним суставом и горизонталью, равному angle (в радианах)
        /// См. чертеж manipulator.png!
        /// </summary>
        public static double[] MoveManipulatorTo(double x, double y, double angle)
        {
            var wristX = x - Cos(angle) * Palm;
            var wristY = y + Sin(angle) * Palm;
            var distanceToWrist = Sqrt(wristX * wristX  + wristY * wristY);
            var elbow = GetABAngle(UpperArm, Forearm, distanceToWrist);
            var shoulder = GetABAngle(UpperArm, distanceToWrist, Forearm) + Atan2(wristY, wristX);
            var wrist = - angle - shoulder - elbow;

            if (double.IsNaN(shoulder) || double.IsNaN(elbow) || double.IsNaN(wrist))
                return new[] { double.NaN, double.NaN, double.NaN };

            return new[] { shoulder, elbow, wrist };
        }
    }

    [TestFixture]
    public class ManipulatorTask_Tests
    {
        [Test]
        public void TestMoveManipulatorTo()
        {
            Random rnd = new Random();
            var x = rnd.Next();
            var y = rnd.Next();
            var angle = rnd.NextDouble() * 2 * PI;
            var angles = ManipulatorTask.MoveManipulatorTo(x, y, angle);
            if (!Double.IsNaN(angles[0]))
            {
                var coordinates = AnglesToCoordinatesTask.GetJointPositions(angles[0], angles[1], angles[2]);
                Assert.AreEqual(x, coordinates[2].X, 1e-5);
                Assert.AreEqual(y, coordinates[2].Y, 1e-5);
            }
        }
    }
}using NUnit.Framework;
using static System.Math;
using static Manipulation.Manipulator;
using static Manipulation.TriangleTask;
using System;

namespace Manipulation
{
    public static class ManipulatorTask
    {
        /// <summary>
        /// Возвращает массив углов (shoulder, elbow, wrist),
        /// необходимых для приведения эффектора манипулятора в точку x и y 
        /// с углом между последним суставом и горизонталью, равному angle (в радианах)
        /// См. чертеж manipulator.png!
        /// </summary>
        public static double[] MoveManipulatorTo(double x, double y, double angle)
        {
            var wristX = x - Cos(angle) * Palm;
            var wristY = y + Sin(angle) * Palm;
            var distanceToWrist = Sqrt(wristX * wristX  + wristY * wristY);
            var elbow = GetABAngle(UpperArm, Forearm, distanceToWrist);
            var shoulder = GetABAngle(UpperArm, distanceToWrist, Forearm) + Atan2(wristY, wristX);
            var wrist = - angle - shoulder - elbow;

            if (double.IsNaN(shoulder) || double.IsNaN(elbow) || double.IsNaN(wrist))
                return new[] { double.NaN, double.NaN, double.NaN };

            return new[] { shoulder, elbow, wrist };
        }
    }

    [TestFixture]
    public class ManipulatorTask_Tests
    {
        [Test]
        public void TestMoveManipulatorTo()
        {
            Random rnd = new Random();
            var x = rnd.Next();
            var y = rnd.Next();
            var angle = rnd.NextDouble() * 2 * PI;
            var angles = ManipulatorTask.MoveManipulatorTo(x, y, angle);
            if (!Double.IsNaN(angles[0]))
            {
                var coordinates = AnglesToCoordinatesTask.GetJointPositions(angles[0], angles[1], angles[2]);
                Assert.AreEqual(x, coordinates[2].X, 1e-5);
                Assert.AreEqual(y, coordinates[2].Y, 1e-5);
            }
        }
    }
}

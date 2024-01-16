using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Math;
using static System.Windows.Forms.Keys;
using static Manipulation.Manipulator;

namespace Manipulation
{
	public static class VisualizerTask
	{
		public static double X = 220;
		public static double Y = -100;
		public static double Alpha = 0.05;
		public static double Wrist = 2 * PI / 3;
		public static double Elbow = 3 * PI / 4;
		public static double Shoulder = PI / 2;

		public static Brush UnreachableAreaBrush = new SolidBrush(Color.FromArgb(255, 255, 230, 230));
		public static Brush ReachableAreaBrush = new SolidBrush(Color.FromArgb(255, 230, 255, 230));
		public static Pen ManipulatorPen = new Pen(Color.Black, 3);
		public static Brush JointBrush = Brushes.Gray;

		public static void KeyDown(Form form, KeyEventArgs key)
		{
            var keyCode = key.KeyCode;
            if (keyCode == Q)
                Shoulder += 0.05;
            if (keyCode == A)
                Shoulder -= 0.05;
            if (keyCode == W)
                Elbow += 0.05;
            if (keyCode == S)
                Elbow -= 0.05;
            Wrist = -Alpha - Shoulder - Elbow;
            form.Invalidate();
        }


		public static void MouseMove(Form form, MouseEventArgs e)
		{
            var shoulderPos = GetShoulderPos(form);
            var newMouseCoordinates = ConvertWindowToMath(new PointF(e.X, e.Y), shoulderPos);
            X = newMouseCoordinates.X;
            Y = newMouseCoordinates.Y;
            UpdateManipulator();
			form.Invalidate();
		}

		public static void MouseWheel(Form form, MouseEventArgs e)
		{
            var epsilon = 120 * 0.1;
            Alpha += e.Delta / epsilon;
			UpdateManipulator();
			form.Invalidate();
		}

		public static void UpdateManipulator()
		{
            var arrayOfAngles = ManipulatorTask.MoveManipulatorTo(X, Y, Alpha);
            if (!double.IsNaN(arrayOfAngles[0]))
            {
                Shoulder = arrayOfAngles[0];
                Elbow = arrayOfAngles[1];
                Wrist = arrayOfAngles[2];
            }
        }

		public static void DrawManipulator(Graphics graphics, PointF shoulderPos)
		{
			var joints = AnglesToCoordinatesTask.GetJointPositions(Shoulder, Elbow, Wrist);
            
			graphics.DrawString($"X={X:0}, Y={Y:0}, Alpha={Alpha:0.00}",
                				new Font(SystemFonts.DefaultFont.FontFamily, 12),
								Brushes.DarkRed, 10, 10);
			
			DrawReachableZone(graphics, ReachableAreaBrush, UnreachableAreaBrush, shoulderPos, joints);

            joints[0] = ConvertMathToWindow(joints[0], shoulderPos);
            joints[1] = ConvertMathToWindow(joints[1], shoulderPos);
            joints[2] = ConvertMathToWindow(joints[2], shoulderPos);

            graphics.DrawLine(ManipulatorPen, shoulderPos, joints[0]);
            graphics.DrawLine(ManipulatorPen, joints[0], joints[1]);
            graphics.DrawLine(ManipulatorPen, joints[1], joints[2]);

            graphics.FillEllipse(JointBrush, new RectangleF(shoulderPos, new SizeF(1, 1)));
            graphics.FillEllipse(JointBrush, new RectangleF(joints[0], new SizeF(1, 1)));
            graphics.FillEllipse(JointBrush, new RectangleF(joints[1], new SizeF(1, 1)));
            graphics.FillEllipse(JointBrush, new RectangleF(joints[2], new SizeF(1, 1)));
        }

		private static void DrawReachableZone(Graphics graphics, Brush reachableBrush,
											  Brush unreachableBrush, PointF shoulderPos, PointF[] joints)
		{
			var rmin = Abs(UpperArm - Forearm);
			var rmax = UpperArm + Forearm;
			var mathCenter = new PointF(joints[2].X - joints[1].X, joints[2].Y - joints[1].Y);
			var windowCenter = ConvertMathToWindow(mathCenter, shoulderPos);

			graphics.FillEllipse(reachableBrush, windowCenter.X - rmax,
                				 windowCenter.Y - rmax, 2 * rmax, 2 * rmax);

			graphics.FillEllipse(unreachableBrush, windowCenter.X - rmin,
                				 windowCenter.Y - rmin, 2 * rmin, 2 * rmin);
		}

		public static PointF GetShoulderPos(Form form)
		{
			return new PointF(form.ClientSize.Width / 2f, form.ClientSize.Height / 2f);
		}

		public static PointF ConvertMathToWindow(PointF mathPoint, PointF shoulderPos)
		{
			return new PointF(mathPoint.X + shoulderPos.X, shoulderPos.Y - mathPoint.Y);
		}

		public static PointF ConvertWindowToMath(PointF windowPoint, PointF shoulderPos)
		{
			return new PointF(windowPoint.X - shoulderPos.X, shoulderPos.Y - windowPoint.Y);
		}
	}
}

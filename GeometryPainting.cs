using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTasks;
using System.Drawing;

namespace GeometryPainting
{
    public static class SegmentExtension
    {
        public static Dictionary<Segment, Color> Colour = new Dictionary<Segment, Color>();

        public static void SetColor(this Segment segment, Color newColor)
        {
            if (!Colour.ContainsKey(segment))
                Colour.Add(segment, newColor);
            else Colour[segment] = newColor;
        }

        public static Color GetColor(this Segment segment)
        {
            if (Colour.ContainsKey(segment))
                return Colour[segment];
            return Color.Black;
        }
    }
}

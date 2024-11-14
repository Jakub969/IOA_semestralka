using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv1.Tools
{
    public static class CoordTransformations
    {
        private const float Xmin = 0.0f;
        private const float Ymin = 0.0f;
        public static float Xmax = 27442.6696f;
        public static float Ymax = 19257.4768f;

        private const int Umin = 0;
        public static int Vmin = 768;
        public static int Umax = 1094;
        private const int Vmax = 0;

        public static PointF FromUVToXY(Point p)
        {
            return new PointF((p.X - Umin) / (float)(Umax - Umin) * (Xmax - Xmin) + Xmin,
                              (p.Y - Vmin) / (float)(Vmax - Vmin) * (Ymax - Ymin) + Ymin);
        }

        public static Point FromXYToUV(PointF w)
        {
            return new Point((int)((w.X - Xmin) / (Xmax - Xmin) * (Umax - Umin) + Umin), 
                             (int)((w.Y - Ymin) / (Ymax - Ymin) * (Vmax - Vmin) + Vmin));
        }
    }
}

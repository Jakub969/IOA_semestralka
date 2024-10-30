using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv1.Interfaces
{
    public interface IDrawable2DObject
    {
        void Draw(Graphics g);

        bool IsHitByMouse(Point mousePosition);
    }
}

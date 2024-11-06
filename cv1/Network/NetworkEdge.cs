using cv1.Interfaces;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace cv1.Network
{
    public class NetworkEdge(NetworkNode parStartNode, NetworkNode parEndNode, int parID) : IDrawable2DObject
    {
        private int id = parID;
        private NetworkNode startNode = parStartNode;
        private NetworkNode endNode = parEndNode;

        public NetworkNode StartNode { get => startNode; }
        public NetworkNode EndNode { get => EndNode; }

        public bool Selected { get; set; }



        public void Draw(Graphics g)
        {
            Point pStart = startNode.Position;
            Point pEnd = endNode.Position;

            using Pen p = new(Color.DarkGray, 2.0f);

            if (Selected)
                p.Color = Color.Blue; 

            g.DrawLine(p, pStart, pEnd);

            // draw the ID number
            int posX = (int)((pEnd.X - pStart.X) / 2.0f);
            int posY = (int)((pEnd.Y - pStart.Y) / 2.0f);

            posX += posX >= 0 ? pStart.X : pEnd.X;
            posY += posY >= 0 ? pStart.Y : pEnd.Y;

            using Font f = new(FontFamily.GenericSansSerif, 9);
            g.DrawString(id.ToString(), f, Brushes.Red, new PointF(posX, posY));
        }

        public bool IsHitByMouse(Point mousePosition)
        {
            using GraphicsPath path = new ();
            path.AddLine(startNode.Position, endNode.Position);
            using Pen p = new(Color.Empty, 8.0f);
            return path.IsOutlineVisible(mousePosition, p);
        }
    }
}

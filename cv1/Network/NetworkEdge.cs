using cv1.Interfaces;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace cv1.Network
{
    [DataContract(Name="NetworkData")]
    public class NetworkEdge(NetworkNode parStartNode, NetworkNode parEndNode, int parID) : IDrawable2DObject
    {
        [DataMember()]
        private int id = parID;
        [DataMember()]
        private int startNodeID = parStartNode.ID;
        [DataMember()]
        private int endNodeID = parEndNode.ID;

        private NetworkNode startNode = parStartNode;
        private NetworkNode endNode = parEndNode;

        public NetworkNode StartNode { get => startNode; }
        public NetworkNode EndNode { get => endNode; }

        public int ID { get { return id; } }

        public int StartNodeID { get { return startNodeID; } }
        public int EndNodeID { get { return endNodeID; } }

        public bool Selected { get; set; }

        public void Draw(Graphics g)
        {
            Point pStart = startNode.Position;
            Point pEnd = endNode.Position;

            using Pen p = new(Color.Black, 2.0f);

            if (Selected)
                p.Color = Color.Blue; 

            g.DrawLine(p, pStart, pEnd);

            // draw the ID number
            int posX = (int)((pEnd.X - pStart.X) / 2.0f);
            int posY = (int)((pEnd.Y - pStart.Y) / 2.0f);

            posX = posX >= 0 ? posX + pStart.X : pEnd.X - posX;
            posY = posY >= 0 ? posY + pStart.Y : pEnd.Y - posY;

            using Font f = new(FontFamily.GenericSansSerif, 6);
            g.DrawString(id.ToString(), f, Brushes.Black, new PointF(posX, posY));
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

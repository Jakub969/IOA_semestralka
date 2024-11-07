using cv1.Interfaces;
using System.Runtime.Serialization;

namespace cv1.Network
{
    [DataContract(Name = "NetworkNode")]
    public class NetworkNode : IDrawable2DObject
    {
        [DataMember()]
        private int id;
        [DataMember()]
        private Size size = new (10, 10);
        public bool Selected { get; set; }
        public Point Position { get; set; }

        public int ID { get { return id; } }

        public Rectangle BoundingRectangle 
        {
            get
            {
                return new(new(Position.X - size.Width / 2, Position.Y - size.Height / 2), size);
            }
        }

        public NetworkNode(Point parPosition, int parID)
        {
            Position = parPosition;
            id = parID;
        }

        public void Draw(Graphics g)
        {
            Rectangle boundRect = BoundingRectangle;

            g.FillEllipse(Brushes.Orange, boundRect);
            g.DrawEllipse(Pens.Red, boundRect);

            using Font f = new(FontFamily.GenericSansSerif, 7);
            g.DrawString(id.ToString(), f, Brushes.Red, new PointF(Position.X + (int)(size.Width / 2.0), Position.Y));

            if (Selected)
            {
                Rectangle selectRetangle = BoundingRectangle;
                selectRetangle.Inflate(2, 2);

                g.DrawRectangle(Pens.Blue, selectRetangle);
            }
        }

        public bool IsHitByMouse(Point mousePosition)
        {
            return BoundingRectangle.Contains(mousePosition);
        }
    }
}

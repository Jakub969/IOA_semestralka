using cv1.Interfaces;
using System.Runtime.Serialization;

namespace cv1.Network
{
    [DataContract(Name = "NetworkNode")]
    public class NetworkNode(Point parPosition, int parID) : IDrawable2DObject
    {
        [DataMember()]
        private int id = parID;
        [DataMember()]
        private Size size = new (10, 10);
        public bool Selected { get; set; }
        public Point Position { get; set; } = parPosition;
        public Point PositionOffset { get; set; }

        public int ID { get { return id; } }

        public Rectangle BoundingRectangle 
        {
            get
            {
                return new(new(Position.X + PositionOffset.X - size.Width / 2, Position.Y + PositionOffset.Y - size.Height / 2), size);
            }
        }

        public void Draw(Graphics g)
        {
            Rectangle boundRect = BoundingRectangle;

            g.FillEllipse(Brushes.Orange, boundRect);
            g.DrawEllipse(Pens.Red, boundRect);

            using Font f = new(FontFamily.GenericSansSerif, 7);
            g.DrawString(id.ToString(), f, Brushes.Red, new PointF(BoundingRectangle.X + size.Width, BoundingRectangle.Y + size.Height));

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

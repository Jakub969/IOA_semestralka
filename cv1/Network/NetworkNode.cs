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
        private Size size = new (12, 12);
        [DataMember()]
        private Point position = parPosition;

        public bool Selected { get; set; }

        public Point Position
        { 
            get
            {
                return new(position.X + PositionOffset.X, position.Y + PositionOffset.Y);
            }

            set
            {
                position = new(position.X + value.X, position.Y + value.Y);
            } 
        }

        public Point PositionOffset { get; set; }

        public int ID { get { return id; } }

        public Rectangle BoundingRectangle 
        {
            get
            {
                return new(new(Position.X - size.Width / 2, Position.Y - size.Height / 2), size);
            }
        }

        public void Draw(Graphics g)
        {
            Rectangle boundRect = BoundingRectangle;

            g.FillEllipse(Brushes.Orange, boundRect);
            g.DrawEllipse(Pens.Red, boundRect);

            using Font f = new(FontFamily.GenericMonospace, 5);

            StringFormat stringFormat = new()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(id.ToString(), f, Brushes.Red, boundRect, stringFormat);

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

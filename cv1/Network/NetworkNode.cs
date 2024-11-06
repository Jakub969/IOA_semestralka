using cv1.Interfaces;

namespace cv1.Network
{

    public class NetworkNode : IDrawable2DObject
    {
        private int id;

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

using cv1.Interfaces;
using System.Runtime.Serialization;
using cv1.Enums;

namespace cv1.Network
{
    [DataContract(Name = "NetworkNode")]
    public class NetworkNode(Point parPosition, int parID) : IDrawable2DObject
    {
        [DataMember()]
        private int id = parID;
        [DataMember()]
        private Size size = new (15, 15);
        [DataMember()]
        private Point position = parPosition;
        [DataMember()]
        public string Name { get; set; } = string.Empty;

        [DataMember()]
        public EnumNodeType Type { get; set; } = EnumNodeType.NotSpecified;

        [DataMember()]
        public float CapacityOrDemand { get; set; } = 0;

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

            using Font f = new("Arial", 6, FontStyle.Bold, GraphicsUnit.Point);

            StringFormat stringFormat = new()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(id.ToString(), f, Brushes.Red, boundRect, stringFormat);
            
            string additionalInfo = $"{Name}\n{TypeToString()}\nKap.: {CapacityOrDemand}";
            using Font infoFont = new("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);

            Point infoPosition = new(Position.X, Position.Y + size.Height / 2 + 15);
            g.DrawString(additionalInfo, infoFont, Brushes.Black, infoPosition, stringFormat);

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

        private string TypeToString()
        {
            return Type switch
            {
                EnumNodeType.PrimarySource => "Primárny zdroj",
                EnumNodeType.Customer => "Zákazník",
                EnumNodeType.PotentialWarehouse => "Možný sklad",
                _ => "Bez špecifikácie"
            };
        }
    }
}

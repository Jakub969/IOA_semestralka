﻿using cv1.Interfaces;
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

        [DataMember]
        private float length = 0;

        [DataMember]
        public bool isLengthManual { get; set; }

        [DataMember]
        public bool IsEnabled { get; set; } = true;

        private NetworkNode startNode = parStartNode;
        private NetworkNode endNode = parEndNode;

        public NetworkNode StartNode { get => startNode; }
        public NetworkNode EndNode { get => endNode; }

        public float Length
        {
            get => isLengthManual ? length : CalculateEuclideanDistance();
            set
            {
                length = value;
                isLengthManual = true;
            }
        }

        public int ID { get { return id; } }

        public int StartNodeID { get { return startNodeID; } }
        public int EndNodeID { get { return endNodeID; } }

        public bool Selected { get; set; }
        public int? RouteIndex { get; set; } = null;


        public void Draw(Graphics g)
        {
            Point pStart = startNode.Position;
            Point pEnd = endNode.Position;

            Color color = RouteIndex.HasValue
                ? GetColorByIndex(RouteIndex.Value)
                : Color.Black;

            using Pen p = new(color, RouteIndex.HasValue ? 3.5f : 2f);

            g.DrawLine(p, pStart, pEnd);

            string edgeInfo = $"ID: {id}, Dĺžka: {Length:F1}";
            int posX = (int)((pEnd.X - pStart.X) / 2.0f);
            int posY = (int)((pEnd.Y - pStart.Y) / 2.0f);

            posX = posX >= 0 ? posX + pStart.X : pEnd.X - posX;
            posY = posY >= 0 ? posY + pStart.Y : pEnd.Y - posY;

            using Font f = new(FontFamily.GenericSansSerif, 6);
            g.DrawString(edgeInfo, f, Brushes.Black, new PointF(posX, posY));
        }
        private Color GetColorByIndex(int index)
        {
            Color[] palette = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Orange,
                Color.Purple, Color.Cyan, Color.Brown, Color.Magenta
            };

            return palette[index % palette.Length];
        }

        public bool IsHitByMouse(Point mousePosition)
        {
            using GraphicsPath path = new ();
            path.AddLine(startNode.Position, endNode.Position);
            using Pen p = new(Color.Empty, 8.0f);
            return path.IsOutlineVisible(mousePosition, p);
        }

        private float CalculateEuclideanDistance()
        {
            Point pStart = startNode.Position;
            Point pEnd = endNode.Position;

            return (float)Math.Sqrt(Math.Pow(pEnd.X - pStart.X, 2) + Math.Pow(pEnd.Y - pStart.Y, 2));
        }

        public void SetAutoLengthCalculation(bool autoCalculate)
        {
            isLengthManual = !autoCalculate;
            if (autoCalculate)
                length = CalculateEuclideanDistance();
        }
    }
}

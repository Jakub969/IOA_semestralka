using cv1.Interfaces;
using System.Xml.Linq;

namespace cv1.Network
{
    public class NetworkData : IDrawable2DObject
    {
        private List<NetworkNode> nodes = [];

        private Bitmap? bitmapOriginalMap;
        public bool BackgroundVisible { get; set; }
        public List<NetworkNode> Nodes { get { return nodes; } }

        public Keys Key { get; set; }

        public bool SeletedAny
        {
            get
            {
                return nodes.Any(x => x.Selected);
            }
        }

        public NetworkData(string parBitmapPath)
        {
            BackgroundVisible = true;  
            Key = Keys.None;    

            if (string.IsNullOrEmpty(parBitmapPath))
                return;

            try
            {
                bitmapOriginalMap = new(parBitmapPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading bitmap" + e.Message);
                return; 
            }
        }

        public void Draw(Graphics g)
        {
            if (BackgroundVisible && bitmapOriginalMap != null)
            {
                g.DrawImage(bitmapOriginalMap, 0, 0);
            }

            foreach(NetworkNode node in nodes)
            {
                node.Draw(g);
            }
        }

        public bool SelectNode(Point mousePosition, bool addSelect = false)
        {
            if (!addSelect)
                nodes.ForEach(x => x.Selected = false);

            foreach (NetworkNode node in nodes)
            {
                if (node.IsHitByMouse(mousePosition))
                {
                    node.Selected = true;
                    return true; 
                }
            }

            return false;
        }

        public bool SelectNode(Rectangle selectRectangle, bool addSelect = false)
        {
            if (!addSelect)
                nodes.ForEach(x => x.Selected = false);

            if (selectRectangle.IsEmpty)
                return false;

            foreach (NetworkNode node in nodes)
            {
                if (selectRectangle.Contains(node.Position))
                {
                    node.Selected = true;
                }
            }

            return false;
        }

        public void RemoveSelected()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Selected == true)
                {
                    nodes.RemoveAt(i); 
                }
            }
        }

        public bool IsHitByMouse(Point mousePosition)
        {
            throw new NotImplementedException();
        }
    }
}

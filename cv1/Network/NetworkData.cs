using cv1.Interfaces;
using System.Runtime.Serialization;

namespace cv1.Network
{
    [DataContract(Name = "NetworkNode")]
    public class NetworkData : IDrawable2DObject
    {
        [DataMember()]
        private int nodeID = 0;
        [DataMember()]
        private int edgeID = 0;

        [DataMember()]
        private List<NetworkNode> nodes = [];
        [DataMember()]
        private List<NetworkEdge> edges = [];
        [DataMember()]
        private string? bitmapPath;

        private Bitmap? bitmapOriginalMap;
        [DataMember()]
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
            bitmapPath = parBitmapPath;

            if (string.IsNullOrEmpty(bitmapPath))
                return;

            try
            {
                bitmapOriginalMap = new(bitmapPath);
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

            foreach (NetworkEdge edge in edges)
            {
                edge.Draw(g);
            }

            foreach (NetworkNode node in nodes)
            {
                node.Draw(g);
            }
        }

        public void InsertNode(Point parPosition)
        {
            nodes.Add(new(parPosition, nodeID++));
        }
        public bool InsertEdge(NetworkNode parStartNode, NetworkNode parEndNode)
        {
            if (parStartNode == parEndNode)
                return false;

            foreach (NetworkEdge edge in edges)
            {
                if ((edge.StartNode == parStartNode && edge.EndNode == parEndNode) ||
                    (edge.StartNode == parEndNode && edge.EndNode == parStartNode))
                    return false;
            }

            edges.Add(new(parStartNode, parEndNode, edgeID++));
            return true;
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
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                if (nodes[i].Selected == true)
                {
                    nodes.RemoveAt(i); 
                }
            }

            // remove edges that no longer have start or end nodes
            var validNodes = new HashSet<NetworkNode>(nodes);
            edges = edges.Where(edge => validNodes.Contains(edge.StartNode) && validNodes.Contains(edge.EndNode)).ToList();
        }

        public NetworkNode? IsNodeHitByMouse(Point parMousePosition)
        {
            foreach (NetworkNode node in nodes)
            {
                if (node.IsHitByMouse(parMousePosition))
                {
                    return node;
                }
            }

            return null;
        }

        public bool IsHitByMouse(Point mousePosition)
        {
            throw new NotImplementedException();
        }
    }
}

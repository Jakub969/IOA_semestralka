using cv1.Interfaces;
using System.Runtime.Serialization;
using cv1.Enums;

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
        private string bitmapPath = string.Empty;
        [DataMember()]
        private bool backgrounVisible;
        [DataMember()]
        private float mapWidth = 0.0f;
        [DataMember()]
        private float mapHeight = 0.0f;

        private Bitmap? bitmapImage;

        public Point NodeDrawingOffset { get; set; }
        public int BackgroundAlpha { get; set; }

        public Bitmap? BitmapImage { get { return bitmapImage; } }
        
        public float MapWidth { get { return mapWidth; } set { mapWidth = value; } }
        public float MapHeight { get { return mapHeight; } set { mapHeight = value; } }


        public string BitmapPath
        {
            get
            {
                return bitmapPath;
            }
            set
            {
                bitmapPath = value;
                LoadBackgroundImage();
            }
        }

        public bool BackgroundVisible 
        { 
            get 
            { 
                return backgrounVisible; 
            } 
            set 
            { 
                backgrounVisible = value;
            } 
        }
        public List<NetworkNode> Nodes { get { return nodes; } }
        public List<NetworkEdge> Edges { get { return edges; } }

        public Keys Key { get; set; }

        public bool SeletedAny
        {
            get
            {
                return nodes.Any(x => x.Selected);
            }
        }

        public NetworkData()
        {
            BackgroundVisible = true;  
            Key = Keys.None;    
        }

        public float[,] CreateAdjacencyMatrix()
        {
            int n = Nodes.Count;
            float[,] adjMatrix = new float[n, n];

            for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                adjMatrix[i, j] = float.PositiveInfinity;

            foreach (var edge in Edges.Where(e => e.IsEnabled))
            {
                int i = Nodes.IndexOf(edge.StartNode);
                int j = Nodes.IndexOf(edge.EndNode);
                adjMatrix[i, j] = edge.Length;
                adjMatrix[j, i] = edge.Length;
            }

            return adjMatrix;
        }

        public bool IsConnected()
        {
            if (Nodes.Count == 0) return true;

            var visited = new HashSet<NetworkNode>();
            void DFS(NetworkNode node)
            {
                visited.Add(node);
                var neighbors = Edges
                    .Where(e => e.IsEnabled && (e.StartNode == node || e.EndNode == node))
                    .Select(e => e.StartNode == node ? e.EndNode : e.StartNode);
                foreach (var neighbor in neighbors.Where(n => !visited.Contains(n)))
                    DFS(neighbor);
            }

            DFS(Nodes.First());
            return visited.Count == Nodes.Count;
        }

        public bool ValidateParameters(out string message)
        {
            bool isPrimarySource = false;
            foreach (var node in Nodes)
            {
                if (node.Type == EnumNodeType.Customer && node.CapacityOrDemand <= 0)
                {
                    message = $"Customer {node.Name} must have a positive demand.";
                    return false;
                }
                if (node.Type == EnumNodeType.PrimarySource && node.CapacityOrDemand <= 0)
                {
                    message = $"Source {node.Name} must have a positive capacity.";
                    return false;
                }
                if (node.Type == EnumNodeType.PrimarySource)
                    isPrimarySource = true;

            }

            if (!isPrimarySource)
            {
                message = "At least one primary source is required.";
                return false;
            }
            message = "All parameters are valid.";
            return true;
        }


        public List<NetworkNode> IsolatedNodes()
        {
            return Nodes.Where(node => !Edges.Any(e => e.StartNode == node || e.EndNode == node)).ToList();
        }


        public void LoadBackgroundImage()
        {
            if (string.IsNullOrEmpty(bitmapPath))
                return;

            try
            {
                bitmapImage = new(bitmapPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading bitmap" + e.Message);
                return;
            }
        }

        public void Draw(Graphics g)
        {
            if (BackgroundVisible && bitmapImage != null)
            {
                g.DrawImage(bitmapImage, 0, 0);
                Size bitmapSize = bitmapImage.Size;

                using SolidBrush semiTransBrush = new (Color.FromArgb(255-BackgroundAlpha, 255, 255, 255));
                g.FillRectangle(semiTransBrush, 0, 0, bitmapSize.Width, bitmapSize.Height);
            }

            foreach (NetworkNode node in nodes)
            {
                if (node.Selected)
                    node.PositionOffset = NodeDrawingOffset;
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

        public NetworkEdge? IsEdgeHitByMouse(Point mousePosition)
        {
            foreach (var edge in edges)
            {
                if (edge.IsHitByMouse(mousePosition))
                    return edge;
            }
            return null;
        }


        public bool HoverOverSelectedNode(Point parMousePosition)
        {
            NetworkNode? nodeMouseOver = IsNodeHitByMouse(parMousePosition);

            return (nodeMouseOver != null && nodeMouseOver.Selected);
        }

        public void UpdateNodesPositionsAfterDrag()
        {
            foreach (NetworkNode node in nodes)
            {
                if (node.Selected)
                    node.Position = NodeDrawingOffset;
            }
        }

        public bool IsHitByMouse(Point mousePosition)
        {
            throw new NotImplementedException();
        }
    }
}

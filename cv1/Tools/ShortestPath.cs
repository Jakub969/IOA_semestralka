using cv1.Network;
using System.Collections.Generic;
using System.Linq;

namespace cv1.Tools
{
    public class ShortestPath
    {
        private readonly NetworkData network;

        public ShortestPath(NetworkData network)
        {
            this.network = network;
        }

        public (List<NetworkNode> path, float totalDistance) FindPath(NetworkNode start, NetworkNode end)
        {
            var distances = new Dictionary<NetworkNode, float>();
            var previousNodes = new Dictionary<NetworkNode, NetworkNode>();
            var nodes = new List<NetworkNode>();

            foreach (var node in network.Nodes)
            {
                distances[node] = float.PositiveInfinity;
                nodes.Add(node);
            }

            distances[start] = 0;

            while (nodes.Any())
            {
                nodes = nodes.OrderBy(n => distances[n]).ToList();
                var currentNode = nodes.First();
                nodes.Remove(currentNode);

                if (currentNode == end)
                    break;

                var neighbors = GetNeighbors(currentNode);

                foreach (var neighbor in neighbors)
                {
                    var edge = network.Edges.FirstOrDefault(e =>
                        (e.StartNode == currentNode && e.EndNode == neighbor) ||
                        (e.EndNode == currentNode && e.StartNode == neighbor));

                    if (edge == null || !edge.IsEnabled)
                        continue;

                    float newDistance = distances[currentNode] + edge.Length;
                    if (newDistance < distances[neighbor])
                    {
                        distances[neighbor] = newDistance;
                        previousNodes[neighbor] = currentNode;
                    }
                }
            }

            // reconstruct path
            var path = new List<NetworkNode>();
            var current = end;

            if (!previousNodes.ContainsKey(end))
                return (new List<NetworkNode>(), float.PositiveInfinity); // No path found

            while (current != null)
            {
                path.Insert(0, current);
                previousNodes.TryGetValue(current, out current);
            }

            return (path, distances[end]);
        }

        private IEnumerable<NetworkNode> GetNeighbors(NetworkNode node)
        {
            return network.Edges
                .Where(e => e.StartNode == node || e.EndNode == node)
                .Select(e => e.StartNode == node ? e.EndNode : e.StartNode);
        }
    }
}

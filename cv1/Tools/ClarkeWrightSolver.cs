using cv1.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cv1.Enums;

namespace cv1.Tools
{
    public class ClarkeWrightSolver
    {
        private NetworkData network;
        private float vehicleCapacity;

        public ClarkeWrightSolver(NetworkData network, float vehicleCapacity)
        {
            this.network = network;
            this.vehicleCapacity = vehicleCapacity;
        }

        public List<List<NetworkNode>> Solve()
        {
            var depot = network.Nodes.FirstOrDefault(n => n.Type == EnumNodeType.PrimarySource);
            if (depot == null) throw new Exception("Depot node not defined.");

            var customers = network.Nodes.Where(n => n.Type == EnumNodeType.Customer).ToList();

            var routes = customers.Select(c => new List<NetworkNode> { c }).ToList();

            var savings = new List<(NetworkNode i, NetworkNode j, float saving)>();

            foreach (var i in customers)
            {
                foreach (var j in customers)
                {
                    if (i == j) continue;

                    float saving = Distance(depot, i) + Distance(depot, j) - Distance(i, j);
                    savings.Add((i, j, saving));
                }
            }

            savings = savings.OrderByDescending(s => s.saving).ToList();

            foreach (var (i, j, _) in savings)
            {
                var routeI = routes.FirstOrDefault(r => r.Contains(i));
                var routeJ = routes.FirstOrDefault(r => r.Contains(j));

                if (routeI == routeJ || routeI == null || routeJ == null) continue;

                if (!IsEndNode(routeI, i) || !IsEndNode(routeJ, j))
                    continue;

                float combinedDemand = routeI.Concat(routeJ)
                                             .Where(n => n.Type == EnumNodeType.Customer)
                                             .Sum(n => n.CapacityOrDemand);

                if (combinedDemand > vehicleCapacity) continue;

                routeI.Remove(depot);
                routeJ.Remove(depot);

                if (routeI.Last() == i && routeJ.First() == j)
                {
                    routeI.AddRange(routeJ);
                }
                else if (routeI.First() == i && routeJ.Last() == j)
                {
                    routeJ.AddRange(routeI);
                    routeI = routeJ;
                }
                else if (routeI.First() == i && routeJ.First() == j)
                {
                    routeI.Reverse();
                    routeI.AddRange(routeJ);
                }
                else if (routeI.Last() == i && routeJ.Last() == j)
                {
                    routeJ.Reverse();
                    routeI.AddRange(routeJ);
                }

                routeI.Insert(0, depot);
                routeI.Add(depot);

                routes.Remove(routeJ);
            }

            return routes;
        }

        private bool IsEndNode(List<NetworkNode> route, NetworkNode node)
        {
            return route.First() == node || route.Last() == node;
        }

        private float Distance(NetworkNode a, NetworkNode b)
        {
            var edge = network.Edges.FirstOrDefault(e =>
                (e.StartNode == a && e.EndNode == b) ||
                (e.EndNode == a && e.StartNode == b));
            return edge?.Length ?? float.PositiveInfinity;
        }

    }

}

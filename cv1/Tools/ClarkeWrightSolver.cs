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
        private Dictionary<(NetworkNode, NetworkNode), float> distanceMatrix;

        public ClarkeWrightSolver(NetworkData network, float vehicleCapacity)
        {
            this.network = network;
            this.vehicleCapacity = vehicleCapacity;
        }

        public List<List<NetworkNode>> Solve()
        {
            var shortestPath = new ShortestPath(network);
            distanceMatrix = new Dictionary<(NetworkNode, NetworkNode), float>();

            foreach (var from in network.Nodes)
            {
                foreach (var to in network.Nodes)
                {
                    if (from == to) continue;

                    var (_, distance) = shortestPath.FindPath(from, to);
                    distanceMatrix[(from, to)] = distance;
                    if (distance == float.PositiveInfinity)
                    {
                        Console.WriteLine($"Žiadna cesta medzi {from.ID} a {to.ID}");
                    }

                }
            }

            var depot = network.Nodes.FirstOrDefault(n => n.Type == EnumNodeType.PrimarySource);
            if (depot == null) throw new Exception("Depot node not defined.");

            var customers = network.Nodes.Where(n => n.Type == EnumNodeType.Customer).ToList();

            var routes = customers.Select(c => new List<NetworkNode> { c }).ToList();
            Console.WriteLine($"Počet počiatočných trás: {routes.Count}");

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

            foreach (var (i, j, saving) in savings)
            {
                var routeI = routes.FirstOrDefault(r => r.Contains(i));
                var routeJ = routes.FirstOrDefault(r => r.Contains(j));

                if (routeI == null || routeJ == null || routeI == routeJ)
                    continue;

                if (!IsEndNode(routeI, i) || !IsEndNode(routeJ, j))
                    continue;

                float combinedDemand = routeI.Concat(routeJ)
                                             .Where(n => n.Type == EnumNodeType.Customer)
                                             .Sum(n => n.CapacityOrDemand);

                if (combinedDemand > vehicleCapacity)
                {
                    Console.WriteLine($"Skipping merge of {i.Name} and {j.Name} due to capacity: {combinedDemand} > {vehicleCapacity}");
                    continue;
                }

                List<NetworkNode> merged = null;

                if (routeI.Last() == i && routeJ.First() == j)
                {
                    merged = new List<NetworkNode>(routeI);
                    merged.AddRange(routeJ);
                }
                else if (routeI.First() == i && routeJ.Last() == j)
                {
                    merged = new List<NetworkNode>(routeJ);
                    merged.AddRange(routeI);
                }
                else if (routeI.First() == i && routeJ.First() == j)
                {
                    routeI.Reverse();
                    merged = new List<NetworkNode>(routeI);
                    merged.AddRange(routeJ);
                }
                else if (routeI.Last() == i && routeJ.Last() == j)
                {
                    routeJ.Reverse();
                    merged = new List<NetworkNode>(routeI);
                    merged.AddRange(routeJ);
                }

                if (merged != null)
                {
                    routes.Remove(routeI);
                    routes.Remove(routeJ);
                    routes.Add(merged);
                }

            }

            foreach (var route in routes)
            {
                route.Insert(0, depot);
                route.Add(depot);
            }
            var allVisited = routes.SelectMany(r => r)
                .Where(n => n.Type == EnumNodeType.Customer)
                .Select(n => n.ID)
                .Distinct()
                .ToList();

            var missing = customers.Where(c => !allVisited.Contains(c.ID)).ToList();

            if (missing.Any())
            {
                Console.WriteLine("Chýbajúci zákazníci vo výsledných trasách:");
                foreach (var m in missing)
                {
                    Console.WriteLine($"Zákazník {m.ID}");
                }
            }


            return routes;
        }

        private bool IsEndNode(List<NetworkNode> route, NetworkNode node)
        {
            return route.First() == node || route.Last() == node;
        }


        private float Distance(NetworkNode a, NetworkNode b)
        {
            if (distanceMatrix.TryGetValue((a, b), out var dist))
                return dist;

            if (distanceMatrix.TryGetValue((b, a), out dist))
                return dist;

            return float.PositiveInfinity;
        }



    }

}

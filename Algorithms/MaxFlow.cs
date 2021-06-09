using System;
using System.Collections.Generic;
using System.Linq;
using GraphDomain;

namespace Algorithms
{
    public class MaxFlow
    {
        public static IEnumerable<KeyValuePair<Edge,int>> Get(Graph graph)
        {
            var initWay = GetFlow(graph,graph);
            
            var flow = graph.Vertices
                .SelectMany(vertex => vertex.Edges)
                .ToDictionary(edge => edge, edge => 0);

            
            AddMin(initWay,flow,graph);

            while(true)
            {
                var net = ResidualNet.Get(graph, flow);
                var way = GetFlow(net,graph);
                if (!way.Any())
                    break;
                AddMin(way,flow,graph);
            }

            return flow.Where(d => d.Value > 0);
        }

        private static IEnumerable<Edge> GetFlow (Graph net, Graph mainGraph)
        {
            var way = WayFinder.Find(
                net.Vertices.Single(v=>Find.Source(mainGraph).Equals(v)),
                net.Vertices.Single(v=>Find.Drain(mainGraph).Equals(v))).ToList();
            
            var wayEdge = new List<Edge>();
            for(var i = 0;i<way.Count -1;i++)
                wayEdge.Add(way[i].Edges.Single(e=>e.End.Equals(way[i+1])));
            return wayEdge;
        }

        private static void AddMin(IEnumerable<Edge> way, IDictionary<Edge, int> flow, Graph mainGraph)
        {
            var min = way.Min(e => e.Data);
            foreach (var edge in way)
            {
                if (mainGraph.Vertices.Single(v=>edge.Start.Equals(v)).Edges.SingleOrDefault(e=>Equals(edge.End, e.End))!=null)
                    flow[edge] += min;
                else flow[edge.Reversed] -= min;
            }
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GraphDomain;

namespace Algorithms
{
    public class ResidualNet
    {
        public static Graph Get(Graph graph, Dictionary<Edge,int> flow)
        {
            var resultGraph = new Graph(true);
            foreach (var vertex in graph.Vertices)
            {
                resultGraph.AddVertex(vertex.Number);
            }

            foreach (var vertex in graph.Vertices)
            {
                var vert = resultGraph.Vertices.Single(v=>v.Equals(vertex));
                foreach (var edge in vertex.Edges)
                {
                    if(flow[edge] > 0)
                        resultGraph.Vertices
                            .Single(v=>v.Equals(edge.End))
                            .AddEdge(flow[edge],vert);

                    if (flow[edge] < edge.Data)
                        vert.AddEdge(edge.Data - flow[edge], resultGraph.Vertices.Single(v=>edge.End.Equals(v)));
                }
            }
            return resultGraph;
        }
    }
}
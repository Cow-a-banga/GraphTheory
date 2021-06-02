using System.Collections.Generic;
using System.Linq;
using Exceptions;
using GraphDomain;

namespace Algorithms
{
    public static class DualsMatching
    {
        public static Dictionary<Vertex, bool> GetParts(Graph graph)
        {
            var vertices = graph.Vertices;
            var parts = new Dictionary<Vertex, bool> {{vertices.First(), true}};
            var queue = new Queue<Vertex>();
            queue.Enqueue(vertices.First());

            while(queue.Count != 0)
            {
                var vertex = queue.Dequeue();
                foreach (var edge in vertex.Edges)
                {

                    if (parts.ContainsKey(edge.End) && parts.ContainsKey(vertex) && parts[edge.End] == parts[vertex])
                        throw new NotDualGraphException();

                    if (parts.ContainsKey(edge.End)) continue;
                    
                    queue.Enqueue(edge.End);
                    parts.Add(edge.End, !parts[vertex]);
                }
            }

            return parts;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using GraphDomain;

namespace Algorithms
{
    public class GreedMatching
    {
        public static IEnumerable<Edge> Match(Graph graph)
        {
            var part = DualsMatching.GetParts(graph)
                .Where(p => !p.Value)
                .Select(p => p.Key)
                .OrderBy(v => v.Edges.Count());

            var list = new List<Edge>();

            foreach (var vertex in part)
            {
                foreach (var edge in vertex.Edges)
                {
                    if (list.Any(e=>e.End.Equals(edge.End))) continue;
                    list.Add(edge);
                    break;
                }
            }

            return list;
        }
    }
}
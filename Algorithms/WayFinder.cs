using System.Collections.Generic;
using System.Linq;
using GraphDomain;

namespace Algorithms
{
    public class WayFinder
    {
        public static IEnumerable<Vertex> Find(Vertex start, Vertex end)
        {
            return FindWay(new List<Vertex>() {start}, end);
        }

        private static IEnumerable<Vertex> FindWay(IList<Vertex> way, Vertex end)
        {
            foreach (var edge in way.Last().Edges)
            {
                if (way.Contains(edge.End)) continue;
                
                way.Add(edge.End);
                FindWay(way, end);
                if (way.Last().Equals(end))
                    return way;
                way.RemoveAt(way.Count - 1);
            }

            return way;
        }
    }
}
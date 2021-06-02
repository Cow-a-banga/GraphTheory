using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using GraphDomain;

namespace Algorithms
{
    public class WaveMatching
    {
        public static IEnumerable<Edge> Match(Graph graph)
        {
            var part = DualsMatching.GetParts(graph)
                .Where(p => !p.Value)
                .Select(p => p.Key);
            var M = GreedMatching.Match(graph).ToList();

            return GetMaxMatching(part, M);
        }

        private static IEnumerable<Edge> GetMaxMatching(IEnumerable<Vertex> part, ICollection<Edge> M)
        {
            var start = part.Where(v => M.All(e => !e.Start.Equals(v)));
            foreach (var vertex in start)
            {
                var result = GetChain(vertex, M, new List<Edge>(), new List<Vertex> {vertex}, false);
                if (result != null)
                {
                    var shouldInM = true;
                    foreach (var edge in result)
                    {
                        if (shouldInM)
                            M.Add(edge);
                        else
                            M.Remove(edge);

                        shouldInM = !shouldInM;
                    }
                    return GetMaxMatching(part, M);
                }
                
                return M;

            }

            return M;
        }

        private static List<Edge> GetChain(Vertex vertex, IEnumerable<Edge> M, List<Edge> acc, ICollection<Vertex> marked, bool isInM)
        {
            if (isInM && M.All(e => !Equals(e.Start, vertex) && !Equals(e.End, vertex)))
                return acc;

            if (!isInM && vertex.Edges.All(M.Contains))
                return null;

            if (isInM && vertex.Edges.All(e => !M.Contains(e)))
                return null;

            foreach (var edge in vertex.Edges.Where(e => M.Contains(e) == isInM && !marked.Contains(e.End))) //Добавить e.Reverse
            {
                acc.Add(edge);
                marked.Add(edge.End);
                var result = GetChain(edge.End, M, acc,marked, !isInM);
                if (result != null)
                    return result;
                marked.Remove(edge.End);
                acc.Remove(edge);
            }

            return null;
        }
    }
}
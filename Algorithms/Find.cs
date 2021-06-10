using System;
using System.Linq;
using Exceptions;
using GraphDomain;

namespace Algorithms
{
    public class Find
    {
        public static Vertex Drain(Graph graph)
        {
            try
            {
                return graph.Vertices.Single(v => !v.Edges.Any());
			}
			catch
			{
                throw new GraphNotNetException();
			}
            
        }

        public static Vertex Source(Graph graph)
        {
            try
            {
                return graph.Vertices
                    .Single(vertex => graph.Vertices
                        .All(v => v.Edges.Count(e => e.End.Equals(vertex)) == 0));
			}
			catch
			{
                throw new GraphNotNetException();
			}

        }
    }
}
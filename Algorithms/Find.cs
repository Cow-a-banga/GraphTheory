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
            var result =  graph.Vertices.SingleOrDefault(v=>!v.Edges.Any());
            if (result != null)
                return result;
            
            throw new GraphNotNetException();
        }

        public static Vertex Source(Graph graph)
        {
            var result = graph.Vertices
                .SingleOrDefault(vertex => graph.Vertices
                    .All(v => v.Edges.Count(e => e.End.Equals(vertex)) == 0));

            if (result != null)
                return result;
            
            throw new GraphNotNetException();
        }
    }
}
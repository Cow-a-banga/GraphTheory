using System.Collections.Generic;
using System.Linq;

namespace GraphDomain
{
    public class Vertex
    {
        private List<Edge> edges;

        public int Number { get; private set; }

        public IEnumerable<Edge> Edges => edges;

        public Vertex(int number)
        {
            Number = number;
            edges = new List<Edge>();
        }

        public Vertex(int number, List<Edge> edges)
        {
            Number = number;
            this.edges = edges;
        }

        public void AddEdge(Edge edge)
        {
            edges.Add(edge);
        }

        public void AddEdge(int data, Vertex end)
        {
            edges.Add(new Edge(data,end));
        }

        public void DeleteEdge(int endVertex)
        {
            edges.RemoveAll(e => e.EndNumber == endVertex);
        }
    }
}

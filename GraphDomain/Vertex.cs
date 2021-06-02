using System.Collections.Generic;
using System.Linq;

namespace GraphDomain
{
    public class Vertex
    {
        private readonly List<Edge> edges;

        private readonly int number;
        public int Number => number;

        public IEnumerable<Edge> Edges => edges;

        public Vertex(int number)
        {
            this.number = number;
            edges = new List<Edge>();
        }

        public Vertex(int number, List<Edge> edges)
        {
            this.number = number;
            this.edges = edges;
        }

        public void AddEdge(int data, Vertex end)
        {
            edges.Add(new Edge(data,end,this));
        }

        public void DeleteEdge(int endVertex)
        {
            edges.RemoveAll(e => e.EndNumber == endVertex);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vertex v)
                return Number.Equals(v.Number);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return number.GetHashCode();
        }
    }
}

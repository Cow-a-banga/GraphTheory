using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp1;

namespace GraphDomain
{
    public class Edge
    {
        public int Data { get; private set; }

        public int EndNumber => End.Number;

        public Edge Reversed => End.Edges.FirstOrDefault(e => Equals(e.End, Start));

        public Vertex End { get; }
        public Vertex Start { get; }

        public Edge(int data, Vertex end, Vertex start)
        {
            Data = data;
            this.End = end;
            this.Start = start;
        }

        public override bool Equals(object obj)
        {
            if (obj is Edge edge)
                return Start.Equals(edge.Start) && End.Equals(edge.End) ||
                       Start.Equals(edge.End) && End.Equals(edge.Start);
            
            return false;
        }
    }
}

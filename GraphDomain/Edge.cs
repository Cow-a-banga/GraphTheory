using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;

namespace GraphDomain
{
    public class Edge
    {
        public int Data { get; private set; }
        private Vertex end;

        public int EndNumber => end.Number;

        public Vertex End => end;

        public Edge(int data, Vertex end)
        {
            Data = data;
            this.end = end;
        }
    }
}

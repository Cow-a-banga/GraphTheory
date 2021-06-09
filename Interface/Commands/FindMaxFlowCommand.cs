using System;
using Algorithms;
using GraphDomain;

namespace Interface.Commands
{
    public class FindMaxFlowCommand:ICommand
    {
        public int CommandNumber { get; set; }
        public string Name => "Максимальный поток";
        public void Execute(ref Graph graph, string[] args)
        {
            foreach (var (edge, value) in MaxFlow.Get(graph))
            {
                Console.WriteLine($"{edge.Start.Number} - {edge.End.Number} ({value})");
            }
        }
    }
}
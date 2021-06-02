using System;
using Algorithms;
using GraphDomain;

namespace Interface.Commands
{
    public class GetMaxMatchingCommand:ICommand
    {
        public int CommandNumber { get; set; }
        public string Name => "Найти максимальное паросочетание";
        public void Execute(ref Graph graph, string[] args)
        {
            foreach (var edge in WaveMatching.Match(graph))
            {
                Console.WriteLine($"{edge.Start.Number} - {edge.End.Number} ({edge.Data})");
            }
        }
    }
}
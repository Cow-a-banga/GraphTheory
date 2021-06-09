using System;
using Algorithms;
using GraphDomain;

namespace Interface.Commands
{
    public class Temp:ICommand
    {
        public int CommandNumber { get; set; }
        public string Name => "Temp";
        public void Execute(ref Graph graph, string[] args)
        {
            foreach (var vertex in MinValueWaveMatching.Match(graph))
            {
                foreach (var value in vertex)
                {
                    Console.Write(value.ToString().PadLeft(5));
                }
                Console.WriteLine();
            }
        }
    }
}
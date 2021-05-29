using System;
using GraphDomain;

namespace Interface.Commands
{
    public class DualMatrixOutputCommand:ICommand
    {
        public int CommandNumber { get; set; }
        public string Name => "Матрица весов двудольного графа";
        public void Execute(ref Graph graph, string[] args)
        {
            foreach (var vertex in graph.GetDualMatrix())
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
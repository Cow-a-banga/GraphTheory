using System;
using GraphDomain;

namespace Interface.Commands
{
    public class MatrixOutputCommand:ICommand
    {
        public int CommandNumber {get;set;}
        public string Name => "Вывести в виде матрицы";
        public void Execute(ref Graph graph, string[] args)
        {
            foreach (var line in graph.GetOutputByMatrix())
                Console.WriteLine(line);
        }
    }
}
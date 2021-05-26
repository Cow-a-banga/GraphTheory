using System;
using GraphDomain;

namespace Interface.Commands
{
    public class ListOutputCommand:ICommand
    {
        public int CommandNumber {get;set;}
        public string Name => "Вывести в виде списка смежности";
        public void Execute(ref Graph graph, string[] args)
        {
            foreach (var line in graph.GetOutputByList())
                Console.WriteLine(line);
        }
    }
}
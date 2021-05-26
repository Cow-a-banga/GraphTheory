using System;
using GraphDomain;

namespace Interface.Commands
{
    public class SetOutputCommand:ICommand
    {
        public int CommandNumber {get;set;}
        public string Name => "Вывести в виде списка рёбер";
        public void Execute(ref Graph graph, string[] args)
        {
            foreach (var line in graph.GetOutputBySets())
                Console.WriteLine(line);
        }
    }
}
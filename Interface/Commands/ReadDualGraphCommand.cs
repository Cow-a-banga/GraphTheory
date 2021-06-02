using System.IO;
using Exceptions;
using GraphDomain;

namespace Interface.Commands
{
    public class ReadDualGraphCommand:ICommand
    {
        public int CommandNumber { get; set; }
        public string Name => "Считать двудольный";
        public void Execute(ref Graph graph, string[] args)
        {
            graph = new Graph();
            if (args.Length == 1)
            {
                using (var reader = new StreamReader(args[0]))
                {
                    graph.InitDualGraph(reader);
                }
            }
            else
                throw new IncorrectCommandException();
        }
    }
}
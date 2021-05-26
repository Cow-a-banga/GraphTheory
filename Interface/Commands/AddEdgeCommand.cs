using Exceptions;
using GraphDomain;

namespace Interface.Commands
{
    public class AddEdgeCommand:ICommand
    {
        public int CommandNumber {get;set;}
        public string Name => "Добавление ребра (<начало> <конец> <вес>)";
        public void Execute(ref Graph graph, string[] args)
        {
            if (args.Length == 3 && int.TryParse(args[0], out int from) &&
                int.TryParse(args[1], out int to) && int.TryParse(args[2], out int data))
                graph.AddEdge(from, to, data);
            else
                throw new IncorrectCommandException();
        }
    }
}
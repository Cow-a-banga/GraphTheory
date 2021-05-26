using Exceptions;
using GraphDomain;

namespace Interface.Commands
{
    public class DeleteEdgeCommand:ICommand
    {
        public int CommandNumber {get;set;}
        public string Name => "Удалить ребро (<начало> <конец>)";
        public void Execute(ref Graph graph, string[] args)
        {
            if (args.Length == 2 && int.TryParse(args[0], out int from) && int.TryParse(args[1], out int to))
                graph.DeleteEdge(from, to);
            else
                throw new IncorrectCommandException();
        }
    }
}
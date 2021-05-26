using Exceptions;
using GraphDomain;

namespace Interface.Commands
{
    public class DeleteVertexCommand:ICommand
    {
        public int CommandNumber {get;set;}
        public string Name => "Удаление вершины (<номер>)";
        public void Execute(ref Graph graph, string[] args)
        {
            if (args.Length == 1 && int.TryParse(args[0], out int num))
                graph.DeleteVertex(num);
            else
                throw new IncorrectCommandException();
        }
    }
}
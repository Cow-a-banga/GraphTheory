using System.Linq;
using Exceptions;
using GraphDomain;

namespace Interface.Commands
{
    public class AddVertexCommand:ICommand
    {
        public int CommandNumber {get;set;}
        public string Name => "Добавление вершины (<номер>)";
        public void Execute(ref Graph graph, string[] args)
        {
            if (args.Length == 1 && int.TryParse(args[0], out int num))
                graph.AddVertex(num);
            else
                throw new IncorrectCommandException();
        }
    }
}
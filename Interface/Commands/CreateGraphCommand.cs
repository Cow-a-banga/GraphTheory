using Exceptions;
using GraphDomain;

namespace Interface.Commands
{
    public class CreateGraphCommand:ICommand
    {
        public int CommandNumber {get;set;}
        public string Name => "Создать пустой граф (<1 - ориентированный, 0 - неориентированный>)";
        public void Execute(ref Graph graph, string[] args)
        {
            if (args != null && args.Length == 1 && int.TryParse(args[0], out int flag))
                graph = new Graph(flag == 1);
            else
                throw new IncorrectCommandException();
        }
    }
}
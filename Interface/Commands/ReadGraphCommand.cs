using System.IO;
using Exceptions;
using GraphDomain;

namespace Interface.Commands
{
    public class ReadGraphCommand:ICommand
    {
        public int CommandNumber {get;set;}
        public string Name => "Загрузить граф из файла (<имя файла>)";

        public void Execute(ref Graph graph, string[] args)
        {
            if (args.Length == 1)
            {
                using (var reader = new StreamReader(args[0]))
                {
                    graph = new Graph(reader);
                }
            }
            else
                throw new IncorrectCommandException();
        }
    }
}
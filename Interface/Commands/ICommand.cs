using GraphDomain;

namespace Interface.Commands
{
    public interface ICommand
    {
        public int CommandNumber { get; set; }
        public string Name { get; }
        public void Execute(ref Graph graph, string[] args);
    }
}
using ConsoleApp1.Interface;
using GraphDomain;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        { 
            var console = new ConsoleInterface(null);
            RegisterCommands.Register(console);
            console.Run();
        }
    }
}

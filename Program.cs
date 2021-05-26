using System;
using System.IO;
using ConsoleApp1.Interface;
using GraphDomain;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleInterface console = new ConsoleInterface(new Graph());
            RegisterCommands.Register(console);
            console.Run();
        }
    }
}

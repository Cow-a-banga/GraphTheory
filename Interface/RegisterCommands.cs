using Interface.Commands;

namespace ConsoleApp1.Interface
{
    public static class RegisterCommands
    {
        public static void Register(ConsoleInterface console)
        {
           console.Register(new CreateGraphCommand());
           console.Register(new ReadGraphCommand());
           console.Register(new ReadDualGraphCommand());
           console.Register(new AddVertexCommand());
           console.Register(new AddEdgeCommand());
           console.Register(new DeleteEdgeCommand());
           console.Register(new DeleteVertexCommand());
           console.Register(new MatrixOutputCommand());
           console.Register(new ListOutputCommand());
           console.Register(new SetOutputCommand());
           console.Register(new DualMatrixOutputCommand());
           console.Register(new GetMaxMatchingCommand());
           console.Register(new FindMaxFlowCommand());
        }
    }
}
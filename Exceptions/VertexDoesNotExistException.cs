using System;

namespace Exceptions
{
    public class VertexDoesNotExistException:Exception
    {
        public VertexDoesNotExistException():base(){}
        public VertexDoesNotExistException(string message):base(message){}
    }
}
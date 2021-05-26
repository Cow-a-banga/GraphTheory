using System;

namespace Exceptions
{
    public class VertexAlreadyExistsException:Exception
    {
        public VertexAlreadyExistsException():base(){}
        public VertexAlreadyExistsException(string message):base(message){}
    }
}
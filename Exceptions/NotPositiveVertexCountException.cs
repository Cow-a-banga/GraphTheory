using System;

namespace Exceptions
{
    public class NotPositiveVertexCountException:Exception
    {
        public NotPositiveVertexCountException():base(){}
        public NotPositiveVertexCountException(string message):base(message){}
    }
}
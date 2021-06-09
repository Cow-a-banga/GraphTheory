using System;

namespace Exceptions
{
    public class GraphNotNetException:Exception
    {
        public GraphNotNetException():base(){}
        public GraphNotNetException(string message):base(message){}
    }
}
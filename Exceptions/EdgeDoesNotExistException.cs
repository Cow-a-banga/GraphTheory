using System;

namespace Exceptions
{
    public class EdgeDoesNotExistException:Exception
    {
        public EdgeDoesNotExistException():base(){}
        public EdgeDoesNotExistException(string message):base(message){}
    }
}
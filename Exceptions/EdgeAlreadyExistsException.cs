using System;

namespace Exceptions
{
    public class EdgeAlreadyExistsException:Exception
    {
        public EdgeAlreadyExistsException():base(){}
        public EdgeAlreadyExistsException(string message):base(message){}
    }
}
using System;

namespace Exceptions
{
    public class NotDualGraphException:Exception
    {
        public NotDualGraphException():base(){}
        public NotDualGraphException(string message):base(message){}
    }
}
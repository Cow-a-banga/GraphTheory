using System;

namespace Exceptions
{
    public class IncorrectCommandException:Exception
    {
        public IncorrectCommandException() : base(){}
        public IncorrectCommandException(string message) : base(message){}
    }
}
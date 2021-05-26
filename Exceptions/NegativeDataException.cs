using System;

namespace Exceptions
{
    public class NegativeDataException:Exception
    {
        public NegativeDataException():base(){}
        public NegativeDataException(string message):base(message){}
    }
}
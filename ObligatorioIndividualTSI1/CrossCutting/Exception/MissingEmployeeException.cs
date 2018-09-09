using System;
using System.Runtime.Serialization;

namespace Shared.Exception
{
    [Serializable]
    public class MissingEmployeeException : System.Exception
    {
        public MissingEmployeeException() : base() { }
        public MissingEmployeeException(string message) : base(message) { }
        public MissingEmployeeException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected MissingEmployeeException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
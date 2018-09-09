using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exception
{
    [Serializable]
    public class WrongEmployeeType : System.Exception
    {
        public WrongEmployeeType() : base() { }
        public WrongEmployeeType(string message) : base(message) { }
        public WrongEmployeeType(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected WrongEmployeeType(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
{ }
    }
}

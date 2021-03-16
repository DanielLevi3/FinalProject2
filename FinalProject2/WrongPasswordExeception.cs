using System;
using System.Runtime.Serialization;

namespace FinalProject2
{
    [Serializable]
    internal class WrongPasswordExeception : Exception
    {
        public WrongPasswordExeception()
        {
        }

        public WrongPasswordExeception(string message) : base(message)
        {
        }

        public WrongPasswordExeception(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongPasswordExeception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
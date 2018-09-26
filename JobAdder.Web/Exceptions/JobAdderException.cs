using System;

namespace JobAdder.Web.Exceptions
{
    public class JobAdderException : ApplicationException
    {
        public JobAdderException(bool isFatal, string operation, Exception exception)
            : base($"JobAdder error encountered - isFatal: { isFatal } | operation: { operation }", exception)
        {
        }
    }
}
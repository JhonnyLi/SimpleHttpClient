using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyHttpClient.ErrorHandling
{
    [Serializable]
    public sealed class ProxyUriException : Exception
    {
        public ProxyUriException()
        {
        }

        public ProxyUriException(string message) : base(message)
        {
        }

        public ProxyUriException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

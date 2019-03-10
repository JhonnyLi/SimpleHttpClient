using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyHttpClient
{
    [Serializable]
    public sealed class ProxyClientUriException : Exception
    {
        public ProxyClientUriException()
        {
        }

        public ProxyClientUriException(string message) : base(message)
        {
        }

        public ProxyClientUriException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

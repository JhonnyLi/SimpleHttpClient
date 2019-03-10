using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProxyHttpClient
{
    // Added as a proxy to avoid requiring more using from the user
    public enum SecurityProtocolNames
    {
        None = 0,
        Ssl3 = 48,
        Tls = 192,
        Tls11 = 768,
        Tls12 = 3072
    }
}

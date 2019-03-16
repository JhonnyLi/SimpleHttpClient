using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SimpleHttpClient
{
    // Added as a proxy to avoid requiring more using from the user
    public enum SecurityProtocolNames
    {
        None = 0,
        HighestPossible = 1,
        Ssl3 = SecurityProtocolType.Ssl3,
        Tls = SecurityProtocolType.Tls,
        Tls11 = SecurityProtocolType.Tls11,
        Tls12 = SecurityProtocolType.Tls12
    }
}

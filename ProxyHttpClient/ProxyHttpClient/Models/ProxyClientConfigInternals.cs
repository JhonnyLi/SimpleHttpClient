using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProxyHttpClient
{
    public abstract class ProxyClientConfigInternals
    {
        /// <summary>
        /// The target Uri
        /// </summary>
        internal Uri _targetUri;

        /// <summary>
        /// Users adds custom headers to this dictionary through extensionmethods.
        /// </summary>
        internal Dictionary<string, string> CustomHeaders { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// The protocol to use when making the request
        /// </summary>
        internal SecurityProtocolType ProtocolType { get; set; } = 0;
    }
}

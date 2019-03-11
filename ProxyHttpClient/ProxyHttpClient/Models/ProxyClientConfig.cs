using System;
using System.Configuration;

namespace ProxyHttpClient
{
    /// <summary>
    /// Client settings
    /// Target url etc
    /// </summary>
    public sealed class ProxyClientConfig : ProxyClientConfigInternals
    {
        /// <summary>
        /// Will throw a ProxyClientUriException if it can't create and Uri from the provided url.
        /// </summary>
        public ProxyClientConfig(string url = null)
        {
            try
            {
                _targetUri = !string.IsNullOrEmpty(url) ? new Uri(url) : null;
            }
            catch (ProxyClientUriException e)
            {
                throw new ProxyClientUriException("Error: Could not create an Uri from the url provided.",e.InnerException);
            }
        }

    }
}

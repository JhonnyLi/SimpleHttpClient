using System;
using System.Configuration;

namespace ProxyHttpClient
{
    /// <summary>
    /// Client settings
    /// Target url etc
    /// </summary>
    public class SimpleClientConfig : SimpleClientConfigInternals
    {
        /// <summary>
        /// Will throw a ProxyClientUriException if it can't create and Uri from the provided url.
        /// </summary>
        public SimpleClientConfig(string url = null)
        {
            _targetUri = CreateUriFromUrl(url);
        }

        public Uri Uri { get { return _targetUri; } }

        protected Uri CreateUriFromUrl(string url)
        {
            if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                Uri result;
                try
                {
                    result = new Uri(url);
                }
                catch (ProxyClientUriException e)
                {
                    throw new ProxyClientUriException("Error: Could not create an Uri from the url provided.", e.InnerException);
                }
                return result;
            }
            else
            {
                throw new ProxyClientUriException("Error: Could not create an Uri from the url provided.");
            }
        }
    }
}

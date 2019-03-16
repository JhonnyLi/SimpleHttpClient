using SimpleHttpClient.ErrorHandling;
using System;
using System.Configuration;

namespace SimpleHttpClient
{
    /// <summary>
    /// Client settings
    /// Target url etc
    /// </summary>
    public class SimpleClientConfig : SimpleClientConfigInternals
    {
        /// <summary>
        /// Will throw a UriException if it can't create and Uri from the provided url.
        /// </summary>
        public SimpleClientConfig(string url = null)
        {
            _targetUri = CreateUriFromUrl(url);
        }

        public Uri Uri { get { return _targetUri; } }

        protected Uri CreateUriFromUrl(string url)
        {
            //Removed try catch, for now, since the if-statement should cover all that can make the new Uri fail
            //If more url parsing is introduced the try catch should be implemented again
            if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return new Uri(url);
            }
            else
            {
                throw new UriException(ErrorConstants.Uri.InvalidUrl);
            }
        }
    }
}

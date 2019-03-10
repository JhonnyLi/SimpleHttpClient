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
        public ProxyClientConfig(string url = null, string appSettingKey = null)
        {
            try
            {
                _targetUri = !string.IsNullOrEmpty(url) ? new Uri(url) : GetUriFromAppsettings(appSettingKey);
            }
            catch (ProxyClientUriException e)
            {
                throw new ProxyClientUriException("Error: Could not create an Uri from the url provided.",e.InnerException);
            }
        }

        #region Privates
        private Uri GetUriFromAppsettings(string key)
        {
            return new Uri(ConfigurationManager.AppSettings[key]);
        }
        #endregion
    }
}

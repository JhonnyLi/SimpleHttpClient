using ProxyHttpClient.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ProxyHttpClient.Models
{
    /// <summary>
    /// Client settings
    /// Target url etc
    /// </summary>
    public partial class ProxyClientConfig
    {
        internal Uri _targetUri;

        public ProxyClientConfig()
        {
            try
            {
#if RELEASE
                _targetUri = new Uri(ConfigurationManager.AppSettings["ProxyClientUrl"]);
#else
                _targetUri = new Uri("http://api.scb.se/OV0104/v1/doris/sv/ssd/BE/BE0101/BE0101A/BefolkningNy");
#endif
            }
            catch (ProxyUriException pue)
            {
                throw pue;
            }
        }

    }
}

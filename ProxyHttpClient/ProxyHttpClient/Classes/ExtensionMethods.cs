using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProxyHttpClient
{
    public static class ExtensionMethods
    {
        public static void AddCustomHeader(this ProxyClientConfig model, string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                model.CustomHeaders.Add(key, value);
            }
        }

        public static void RemoveCustomHeader(this ProxyClientConfig model, string key)
        {
            if (!string.IsNullOrEmpty(key) && model.CustomHeaders.ContainsKey(key))
            {
                model.CustomHeaders.Remove(key);
            }
        }

        /// <summary>
        /// Specify the type of protocol you need to use.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="protocol"></param>
        public static void AddProtocolTypeByName(this ProxyClientConfig model, SecurityProtocolNames protocol)
        {
            switch (protocol)
            {
                case SecurityProtocolNames.Ssl3:
                    model.ProtocolType = SecurityProtocolType.Ssl3;
                    break;
                case SecurityProtocolNames.Tls:
                    model.ProtocolType = SecurityProtocolType.Tls;
                    break;
                case SecurityProtocolNames.Tls11:
                    model.ProtocolType = SecurityProtocolType.Tls11;
                    break;
                case SecurityProtocolNames.Tls12:
                    model.ProtocolType = SecurityProtocolType.Tls12;
                    break;
                case SecurityProtocolNames.None:
                default:
                    model.ProtocolType = 0;
                    break;

            }

        }
    }
}

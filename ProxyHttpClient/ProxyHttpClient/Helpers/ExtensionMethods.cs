using System.Net;

namespace SimpleHttpClient
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Add a custom header to the request
        /// </summary>
        /// <param name="model"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>Returns True if successful and False if something went wrong</returns>
        public static bool AddCustomHeader(this SimpleClientConfig model, string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value) && !model.CustomHeaders.ContainsKey(key))
            {
                model.CustomHeaders.Add(key, value);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Remove a custom header from the request
        /// </summary>
        /// <param name="model"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool RemoveCustomHeader(this SimpleClientConfig model, string key)
        {
            if (!string.IsNullOrEmpty(key) && model.CustomHeaders.ContainsKey(key))
            {
                model.CustomHeaders.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Specify the type of protocol you need to use.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="protocol"></param>
        public static bool AddProtocolTypeByName(this SimpleClientConfig model, SecurityProtocolNames protocol)
        {
            bool result = true;
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
                case SecurityProtocolNames.HighestPossible:
                    model.ProtocolType = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    break;
                case SecurityProtocolNames.None:
                    model.ProtocolType = 0;
                    break;
                default:
                    result = false;
                    break;
            }

            return result;

        }
    }
}

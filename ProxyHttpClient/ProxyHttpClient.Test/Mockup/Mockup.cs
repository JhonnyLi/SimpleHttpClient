using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyHttpClient.Test
{
    public static class Mockup
    {
        public const string MockUrl = "http://www.google.se";
        public const string MockCustomHeaderKey = "key";
        public const string MockCustomHeaderValue = "value";

        public static ProxyClientConfig GetMockupConfig(string url)
        {
            var model = new ProxyClientConfig(url);
            return model;
        }
        public static ProxyClientConfig GetMockupConfig()
        {
            var model = new ProxyClientConfig(MockUrl);
            return model;
        }

        public static ProxyClientConfig GetMockupConfigWithCustomHeader()
        {
            var model = new ProxyClientConfig(MockUrl);
            model.AddCustomHeader(MockCustomHeaderKey, MockCustomHeaderValue);
            return model;
        }
    }
}

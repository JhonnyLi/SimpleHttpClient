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

        public static SimpleClientConfig GetMockupConfig(string url)
        {
            var model = new SimpleClientConfig(url);
            return model;
        }
        public static SimpleClientConfig GetMockupConfig()
        {
            var model = new SimpleClientConfig(MockUrl);
            return model;
        }

        public static SimpleClientConfig GetMockupConfigWithCustomHeader()
        {
            var model = new SimpleClientConfig(MockUrl);
            model.AddCustomHeader(MockCustomHeaderKey, MockCustomHeaderValue);
            return model;
        }
    }
}

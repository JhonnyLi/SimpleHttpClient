namespace SimpleHttpClient.Test
{
    public static class Mockup
    {
        /// <summary>
        /// Valid url for Uri creation
        /// Uri requires protocol to be specified
        /// ex: http://  || https:// || //
        /// </summary>
        public const string MockUrl = "http://www.google.se";
        /// <summary>
        /// Invalid url for Uri creation
        /// Uri requires protocol to be specified
        /// ex: http://  || https:// || //
        /// </summary>
        public const string MockInvalidUrl = "www.google.se";
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

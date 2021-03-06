﻿using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SimpleHttpClient
{
    public class SimpleClient
    {
        /// <summary>
        /// Method Post
        /// Using the config settings as setup for the request.
        /// </summary>
        /// <typeparam name="T">Any serializable class</typeparam>
        /// <param name="config">Contains all the parameters needed to complete the call</param>
        /// <param name="model">The data that will be serialized and sent with the request</param>
        /// <returns>Task<string></returns>
        public Task<string> PostRequestAsync<T>(SimpleClientConfig config, T model)
        {
            Task<string> result = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    SetSecurityProtocol(config.ProtocolType);

                    var jsonContent = JsonConvert.SerializeObject(model);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    AddCustomHeaders(client, config.CustomHeaders);
                    client.DefaultRequestHeaders.Authorization = null;
                    var byteContent = CreateBinaryContent(jsonContent);

                    Task<HttpResponseMessage> response = client.PostAsync(config._targetUri, byteContent);
                    response.Result.EnsureSuccessStatusCode();

                    result = response.Result.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
            return result;
        }

        private void SetSecurityProtocol(SecurityProtocolType protocol)
        {
            if (protocol != 0)
            {
                ServicePointManager.SecurityProtocol = protocol;
            }
        }

        private void AddCustomHeaders(HttpClient client, Dictionary<string,string> headers)
        {
            if (headers.Count > 0)
            {
                try
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                catch
                {
                    //May not be neccessary
                }

            }
        }

        private ByteArrayContent CreateBinaryContent(string jsonContent)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
            var byteContent = new ByteArrayContent(buffer);
            //Add content type headers to the package itself
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}

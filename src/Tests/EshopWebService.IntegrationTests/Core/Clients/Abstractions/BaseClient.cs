using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using EshopWebService.IntegrationTests.Common.Exceptions;
using EshopWebService.IntegrationTests.Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EshopWebService.IntegrationTests.Core.Clients.Abstractions
{
    public abstract class BaseClient
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;
        private readonly Lazy<JsonSerializerSettings> _settings;

        private JsonSerializerSettings JsonSerializerSettings => _settings.Value;

        protected BaseClient(string baseUrl, HttpClient httpClient)
        {
            _baseUrl = baseUrl;
            _httpClient = httpClient;
            _settings = new Lazy<JsonSerializerSettings>(CreateSerializerSettings);
        }

        #region JsonSerializerSettings

        protected virtual void UpdateJsonSerializerSettings(JsonSerializerSettings jsonSerializerSettings)
        {
        }

        private JsonSerializerSettings CreateSerializerSettings()
        {
            var settings = new JsonSerializerSettings();
            UpdateJsonSerializerSettings(settings);
            return settings;
        }

        #endregion

        #region Get

        protected Task<TOut> GetAsync<TIn, TOut>(string endpoint, TIn data, CancellationToken cancellationToken, Regex regexFilterForResponseData = null)
        {
            return SendAsync<TOut>(
                endpoint,
                request =>
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                },
                cancellationToken,
                stringBuilder => data.ToHttpQuery(stringBuilder),
                regexFilterForResponseData);
        }

        protected Task<TOut> GetAsync<TOut>(string endpoint, CancellationToken cancellationToken, Regex regexFilterForResponseData = null)
        {
            return SendAsync<TOut>(
                endpoint,
                request =>
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                },
                cancellationToken,
                regexFilterForResponseData: regexFilterForResponseData
            );
        }

        #endregion

        #region Post

        protected Task<TOut> PostAsync<TIn, TOut>(string endpoint, TIn data, CancellationToken cancellationToken, Regex regexFilterForResponseData = null)
        {
            return SendAsync<TOut>(
                endpoint,
                request =>
                {
                    var content = new StringContent(JsonConvert.SerializeObject(data, _settings.Value));
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                },
                cancellationToken,
                regexFilterForResponseData: regexFilterForResponseData
            );
        }

        protected Task PostAsync(string endpoint, CancellationToken cancellationToken)
        {
            return SendAsync<string>(
                endpoint,
                request =>
                {
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                },
                cancellationToken,
                noResponseData: true
            );
        }

        protected Task<TOut> PostAsync<TOut>(string endpoint, IEnumerable<KeyValuePair<string, string>> formData, CancellationToken cancellationToken, Regex regexFilterForResponseData = null)
        {
            return SendAsync<TOut>(
                endpoint,
                request =>
                {
                    request.Content = new FormUrlEncodedContent(formData);
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                },
                cancellationToken,
                regexFilterForResponseData: regexFilterForResponseData
            );
        }

        #endregion

        #region Put

        protected Task<TOut> PutAsync<TIn, TOut>(string endpoint, TIn data, CancellationToken cancellationToken, Regex regexFilterForResponseData = null)
        {
            return SendAsync<TOut>(
                endpoint,
                request =>
                {
                    var content = new StringContent(JsonConvert.SerializeObject(data, _settings.Value));
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new HttpMethod("PUT");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                },
                cancellationToken,
                regexFilterForResponseData: regexFilterForResponseData
            );
        }

        protected Task PutAsync(string endpoint, CancellationToken cancellationToken)
        {
            return SendAsync<string>(
                endpoint,
                request =>
                {
                    request.Method = new HttpMethod("PUT");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                },
                cancellationToken,
                noResponseData: true
            );
        }

        protected Task<TOut> PutAsync<TOut>(string endpoint, IEnumerable<KeyValuePair<string, string>> formData, CancellationToken cancellationToken, Regex regexFilterForResponseData = null)
        {
            return SendAsync<TOut>(
                endpoint,
                request =>
                {
                    request.Content = new FormUrlEncodedContent(formData);
                    request.Method = new HttpMethod("PUT");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                },
                cancellationToken,
                regexFilterForResponseData: regexFilterForResponseData
            );
        }

        #endregion

        #region ProcessCall

        protected virtual void PrepareRequest(HttpClient httpClient, HttpRequestMessage httpRequestMessage, string url)
        {
        }

        protected virtual void PrepareRequest(HttpClient httpClient, HttpRequestMessage httpRequestMessage, StringBuilder urlBuilder)
        {
        }

        protected virtual void ProcessResponse(HttpClient httpClient, HttpResponseMessage httpRequestMessage)
        {
        }

        protected virtual void PrepareUrlBuilder(StringBuilder stringBuilder)
        {
            stringBuilder.Append(_baseUrl != null ? _baseUrl.TrimEnd('/') : string.Empty);
        }

        private async Task<T> SendAsync<T>(string endpoint, Action<HttpRequestMessage> prepareHttpRequestMessage, CancellationToken cancellationToken, Action<StringBuilder> prepareUrlBuilder = null, Regex regexFilterForResponseData = null,
            bool noResponseData = false)
        {
            var urlBuilder = new StringBuilder();

            PrepareUrlBuilder(urlBuilder);

            urlBuilder.Append(endpoint != null ? endpoint.TrimEnd('/') : string.Empty);

            prepareUrlBuilder?.Invoke(urlBuilder);

            using (var request = new HttpRequestMessage())
            {
                prepareHttpRequestMessage(request);

                PrepareRequest(_httpClient, request, urlBuilder);

                var url = urlBuilder.ToString();
                Debug.WriteLine($"Calling api => {url}");

                request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                PrepareRequest(_httpClient, request, url);

                using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                    if (response.Content?.Headers != null)
                    {
                        foreach (var item in response.Content.Headers)
                        {
                            headers[item.Key] = item.Value;
                        }
                    }

                    ProcessResponse(_httpClient, response);

                    if (response.IsSuccessStatusCode)
                    {
                        if (noResponseData)
                        {
                            return default;
                        }

                        var objectResponse = await ReadObjectResponseAsync<T>(response, headers, regexFilterForResponseData);
                        if (objectResponse.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", response.StatusCode, objectResponse.Text, headers, null);
                        }

                        return objectResponse.Object;
                    }

                    var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync(cancellationToken);
                    throw new ApiException("The HTTP status code of the response was not expected (" + response.StatusCode + ").", response.StatusCode, responseData, headers, null);
                }
            }
        }

        #endregion

        #region ProcessResponse

        protected virtual Task ReadObjectResponseAsync(StreamReader streamReader, JsonTextReader jsonTextReader)
        {
            return Task.CompletedTask;
        }

        protected async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, Regex regexFilterForResponseData = null)
        {
            try
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                using (var streamReader = new StreamReader(responseStream))
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    await ReadObjectResponseAsync(streamReader, jsonTextReader);

                    var serializer = JsonSerializer.Create(JsonSerializerSettings);
                    var typedBody = serializer.Deserialize<JObject>(jsonTextReader);
                    var data = typedBody.FilterData<T>(regexFilterForResponseData);
                    return new ObjectResponseResult<T>(data, string.Empty);
                }
            }
            catch (JsonException exception)
            {
                var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                throw new ApiException(message, response.StatusCode, string.Empty, headers, exception);
            }
        }

        protected readonly struct ObjectResponseResult<T>
        {
            public T Object { get; }

            public string Text { get; }

            public ObjectResponseResult(T responseObject, string responseText)
            {
                Object = responseObject;
                Text = responseText;
            }
        }

        #endregion
    }
}
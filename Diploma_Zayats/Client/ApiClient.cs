using System;
using Diploma_Zayats.Utilities.Configuration;
using NLog;
using NLog.Config;
using RestSharp;
using RestSharp.Authenticators;

namespace Diploma_Zayats.Client
{
    public class ApiClient
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly RestClient _restClient;

        public ApiClient()
        {
            var options = new RestClientOptions(Configurator.AppSettings.URL)
            {
                Authenticator = new JwtAuthenticator(Configurator.Admin.Token),
                ThrowOnAnyError = true,
                MaxTimeout = 10000
            };

            _restClient = new RestClient(options);
        }

        public RestResponse Execute(RestRequest request)
        {
            _logger.Info("Request:" + request.Resource);
            var response = _restClient.Execute(request);
            
            _logger.Info("Response Status:" + response.ResponseStatus);
            _logger.Info("Response Body:" + response.Content);

            return response;
        }
        
        public T Execute<T>(RestRequest request) where T : new()
        {
            _logger.Info("Request:" + request.Resource);
            var response = _restClient.Execute<T>(request);
            
            _logger.Info("Response Status:" + response.ResponseStatus);
            _logger.Info("Response Body:" + response.Content);
            
            if (response.ErrorException != null)
            {
                _logger.Error("Request failed with error: " + response.ErrorException);
                throw response.ErrorException;
            }

            return response.Data;
        }
    }
}


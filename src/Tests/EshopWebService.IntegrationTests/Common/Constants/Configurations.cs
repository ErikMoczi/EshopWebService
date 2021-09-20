using System;

namespace EshopWebService.IntegrationTests.Common.Constants
{
    // TODO load from appsettings.json
    public static class ConfigurationHelper
    {
        public static TimeSpan HttpClientTimeOut => new(0, 0, 10, 0);
    }

    public static class Configurations
    {
        public const string BaseUrl = "/api/";

        #region PublicApiV1Endpoints

        public static class PublicApiV1Endpoints
        {
            public static class ProductApi
            {
                public const string Controller = "/v1/product/";
                public static string GetProductById(int id) => $"/{id}";
                public static string UpdateProduct => string.Empty;
                public static string GetAllProduct => string.Empty;
            }
        }

        #endregion

        #region PublicApiV2Endpoints

        public static class PublicApiV2Endpoints
        {
            public static class ProductApi
            {
                public const string Controller = "/v2/product/";
                public static string GetProductById(int id) => $"/{id}";
                public static string GetAllProduct => string.Empty;
            }
        }

        #endregion
    }
}
using System;
using System.Net;
using System.Threading.Tasks;
using EshopWebService.IntegrationTests.Common.Exceptions;
using Xunit;

namespace EshopWebService.IntegrationTests.Common.Helpers
{
    public static class ApiExceptionHelper
    {
        public static async Task CheckErrorDuringApiCallAsync(Func<Task> action, HttpStatusCode httpStatusCode)
        {
            var exception = await Record.ExceptionAsync(action).ConfigureAwait(false);

            Assert.NotNull(exception);
            Assert.IsType<ApiException>(exception);

            var apiException = (ApiException)exception;
            Assert.Equal(httpStatusCode, apiException.StatusCode);
        }
    }
}
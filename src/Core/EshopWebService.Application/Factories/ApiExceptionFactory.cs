using EshopWebService.Application.Exceptions;

namespace EshopWebService.Application.Factories
{
    public static class ApiExceptionFactory
    {
        public static ApiException Throw()
        {
            throw new ApiException();
        }

        public static ApiException Throw(string message)
        {
            throw new ApiException(message);
        }

        public static ApiException Throw(string message, params object[] args)
        {
            throw new ApiException(message, args);
        }
    }
}
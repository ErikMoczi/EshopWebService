using EshopWebService.Application.DTOs.Result;

namespace EshopWebService.Application.Factories
{
    public static class ResultDtoFactory
    {
        public static IResultDto Fail()
        {
            return new ResultDto { Success = false };
        }

        public static IResultDto Fail(string message)
        {
            return new ResultDto { Success = false, Message = message };
        }

        public static IResultDto Success()
        {
            return new ResultDto { Success = true };
        }

        public static IResultDto Success(string message)
        {
            return new ResultDto { Success = true, Message = message };
        }

        public static ResultDto<T> Fail<T>()
        {
            return new ResultDto<T> { Success = false };
        }

        public static ResultDto<T> Fail<T>(string message)
        {
            return new ResultDto<T> { Success = false, Message = message };
        }

        public static ResultDto<T> Success<T>()
        {
            return new ResultDto<T> { Success = true };
        }

        public static ResultDto<T> Success<T>(string message)
        {
            return new ResultDto<T> { Success = true, Message = message };
        }

        public static ResultDto<T> Success<T>(T data)
        {
            return new ResultDto<T> { Success = true, Data = data };
        }

        public static ResultDto<T> Success<T>(T data, string message)
        {
            return new ResultDto<T> { Success = true, Data = data, Message = message };
        }
    }
}
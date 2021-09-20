using EshopWebService.Application.DTOs.Result;
using Xunit;

namespace EshopWebService.IntegrationTests.Common.Extensions
{
    public static class ResultDtoExtensions
    {
        public static void AssertResultDto(this IResultDto responseDto, bool success)
        {
            Assert.Equal(success, responseDto.Success);
        }

        public static void AssertResultDtoStatusOk(this IResultDto responseDto)
        {
            responseDto.AssertResultDto(true);
        }
    }
}
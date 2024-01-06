using System.Net;
using GameProject.API.Models;
using GameProject.Application.Common.DTO;
using GameProject.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace GameProject.API.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        ErrorDetail errorDetail = new ErrorDetail();
        int statusCode;
        switch (exception)
        {
            case BadRequestException badRequestException:
                statusCode = StatusCodes.Status400BadRequest;
                errorDetail.Description = badRequestException.Message;
                break;
            case NotFoundException notFoundException:
                statusCode = StatusCodes.Status404NotFound;
                errorDetail.Description = notFoundException.Message;
                break;
            default:
                statusCode = StatusCodes.Status500InternalServerError;
                errorDetail.Description = exception.Message;
                break;
        }

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(errorDetail, cancellationToken: cancellationToken);

        return true;
    }
}
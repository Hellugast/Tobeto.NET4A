using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.ExceptionsUpdated
{
    public class ValidationExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ValidationException)
                return false;
            //httpContext.Response.StatusCode = StatusCodes.Status100Continue;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                Title = /*exception.GetType().ToString()*/"validation hatası title deneme",
                Status = StatusCodes.Status100Continue,//deneme için status100
                Message = exception.Message + " validation message edit test",
            });

            return true;
        }

    }

    public class ValidationException : Exception
    {
        //public string Errors { get; set; } = "Validation error";
        //public ValidationException()
        //{ }
        //public ValidationException(string errors) => Errors = errors;
        //public override string ToString()
        //{
        //    return Errors;
        //}

    }
}

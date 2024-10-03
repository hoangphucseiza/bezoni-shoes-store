using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Errors.Authentication
{
    public class ValidateException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public string ErrorMessage { get; }

        // Constructor nhận thông điệp từ tham số
        public ValidateException(string message)
        {
            ErrorMessage = message;
        }
    }
}

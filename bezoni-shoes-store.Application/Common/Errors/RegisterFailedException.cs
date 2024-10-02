using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Errors
{
    public class RegisterFailedException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode  { get; } = HttpStatusCode.BadRequest;
        public string ErrorMessage { get; }

        public RegisterFailedException(string message)
        {
            ErrorMessage = message;
        }

    }
}

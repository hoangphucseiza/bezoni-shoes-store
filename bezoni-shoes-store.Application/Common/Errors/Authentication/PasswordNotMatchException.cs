using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Errors.Authentication
{
    public class PasswordNotMatchException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public string ErrorMessage => "Password Not Match";
    }
}

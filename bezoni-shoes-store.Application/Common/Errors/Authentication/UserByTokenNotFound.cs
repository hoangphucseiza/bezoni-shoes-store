﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Errors.Authentication
{
    public class UserByTokenNotFound : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string ErrorMessage => "User By Token Not Found";
    }
}

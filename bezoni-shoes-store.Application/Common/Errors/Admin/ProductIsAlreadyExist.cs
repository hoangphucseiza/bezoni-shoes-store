using System.Net;

namespace bezoni_shoes_store.Application.Common.Errors.Admin
{
    public class ProductIsAlreadyExist : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Product is already exist";
    }
}

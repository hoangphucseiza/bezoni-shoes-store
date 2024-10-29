using System.Net;

namespace bezoni_shoes_store.Application.Common.Errors.Admin
{
    public class CategoryNotFound : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string ErrorMessage => "Category Not Found";
    }
}

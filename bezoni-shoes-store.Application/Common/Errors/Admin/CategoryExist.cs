using System.Net;

namespace bezoni_shoes_store.Application.Common.Errors.Admin
{
    public class CategoryExist : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Category already exists";
    }
}

using System.Net;

namespace bezoni_shoes_store.Application.Common.Errors.Admin
{
    public class ItemExist : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Item Exits";
    }
}

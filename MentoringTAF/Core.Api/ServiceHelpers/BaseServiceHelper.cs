using Core.Api.Services;

namespace Core.Api.ServiceHelpers
{
    public class BaseServiceHelper
    {
        protected BaseServiceHelper(SessionManager sessionManager)
        {
            BaseService = new BaseService(sessionManager);
        }

        protected BaseService BaseService { get; set; }
    }
}

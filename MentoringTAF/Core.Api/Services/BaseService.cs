namespace Core.Api.Services
{
    public class BaseService
    {
        public BaseService(SessionManager sessionManager)
        {
            SessionManager = sessionManager;
        }

        protected SessionManager SessionManager { get; set; }

        protected const string ProjectName = "MKARALIOU_PERSONAL";
    }
}

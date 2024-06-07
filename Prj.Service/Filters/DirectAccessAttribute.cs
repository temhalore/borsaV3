using Microsoft.AspNetCore.Mvc.Filters;
using Prj.BAL.Managers.Helper.Interfaces;

namespace Prj.Service.Filters
{
    public class DirectAccessAttribute : ActionFilterAttribute
    {
        private IHelperManager _helperManager;
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
                      
        }

        public override void OnActionExecuting(ActionExecutingContext actionExecutedContext)
        {
            if (_helperManager == null)
            {
                _helperManager = (IHelperManager)actionExecutedContext.HttpContext.RequestServices.GetService(typeof(IHelperManager));
            }
        }
    }
}

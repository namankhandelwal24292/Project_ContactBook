using ContactBook.Controllers;
using ContactBook.Services;
using ContactBook.Services.InterFace;
using System;
using System.Web.Mvc;
using System.Web.SessionState;

namespace ContactBook
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            IContactService contactService = new ContactService();
            var controller = new HomeController(contactService);
            return controller;
        }
        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(
           System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}

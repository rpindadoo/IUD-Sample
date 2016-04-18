using System.Web.Http.ExceptionHandling;

namespace IUD.Api.ErrorHandling
{
    public class ErrorHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ErrorResult(context.Request);
        }
    }
}
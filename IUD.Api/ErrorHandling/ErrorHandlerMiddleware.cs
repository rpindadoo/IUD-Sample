using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace IUD.Api.ErrorHandling
{
    public class ErrorHandlerMiddleware : OwinMiddleware
    {
        public ErrorHandlerMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.WriteAsync("Another error handled here! Do Something with it");
            }
        }
    }
}
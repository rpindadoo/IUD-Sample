using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace IUD.Api.ErrorHandling
{
    public class ErrorResult : IHttpActionResult
    {
        public ErrorResult(HttpRequestMessage request)

        {
            Request = request;
        }

        public HttpRequestMessage Request { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                RequestMessage = Request,
                Content = new StringContent("Error handled here! Do Something with it", Encoding.UTF8)
            });
        }
    }
}
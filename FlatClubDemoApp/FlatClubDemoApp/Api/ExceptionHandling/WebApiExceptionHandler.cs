using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using DemoApp.Commonm;
using FlatClubDemoApp.Logging;

namespace FlatClubDemoApp.Api.ExceptionHandling
{
    public class WebApiExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exceptionFullInfo = LogDataProvider.GetExceptionFullInfo(context.Exception);

            var logger = AppServiceLocator.Current.GetInstance<ILogger>();
            logger.Write(exceptionFullInfo.ToString());

            
            context.Result = new TextPlainExceptionResult
            {
                Response = new BaseResponse { Status = -1},
                Request = context.Request
            };
        }

        private class TextPlainExceptionResult : IHttpActionResult
        {
            public BaseResponse Response { get; set; }
            public HttpRequestMessage Request { private get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
               
                if (Request != null)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK, Response);
                    response.Headers.Add("X-Requested-AppHttpMessage", "X-Requested-AppHttpMessage");

                    return Task.FromResult(response);
                }

                using (var httpResponseMessage = new HttpResponseMessage
                {
                    Content = new ObjectContent(Response.GetType(), Response, new JsonMediaTypeFormatter())
                })
                {
                    httpResponseMessage.Headers.Add("X-Requested-AppHttpMessage", "X-Requested-AppHttpMessage");
                    return Task.FromResult(httpResponseMessage);
                }
            }
        }
    }
}
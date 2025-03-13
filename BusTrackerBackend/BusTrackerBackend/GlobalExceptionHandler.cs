using Contracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;

namespace BusTrackerBackend
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerManager _logger;

        public GlobalExceptionHandler(ILoggerManager logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
            Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";

            var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                _logger.LogError($"Something went wrong: {exception.Message}");

                await httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = contextFeature.Error.Message,
                }.ToString());
            }

            return true;
        }
    }


}

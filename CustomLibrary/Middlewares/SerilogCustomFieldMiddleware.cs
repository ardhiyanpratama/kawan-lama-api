using CustomLibrary.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CustomLibrary.Middlewares
{
	public class SerilogCustomFieldMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        private readonly IIdentityService _identityService;

        public SerilogCustomFieldMiddleware(ILogger<SerilogCustomFieldMiddleware>logger,
            RequestDelegate next,
            IIdentityService identityService)
        {
            _next = next;
            _identityService = identityService;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //LogContext.PushProperty("Host", requestedHost);

            //var remoteIp = httpContext.Connection.RemoteIpAddress.ToString();
            //LogContext.PushProperty("IP", !string.IsNullOrWhiteSpace(remoteIp) ? remoteIp : "unknown");

            //var method = httpContext.Request.Method;
            //LogContext.PushProperty("Method", method);

            httpContext.Request.EnableBuffering();

            var reader = new StreamReader(httpContext.Request.Body);
            var requestedHost = httpContext.Request.Host.Host;
            var remoteIp = httpContext.Connection.RemoteIpAddress.ToString();
            var remoteIpResult = !string.IsNullOrWhiteSpace(remoteIp) ? remoteIp : "unknown";

            string body = await reader.ReadToEndAsync();
            _logger.LogInformation(
                $"Status Code : {httpContext.Response.StatusCode}\n" +
                $"User : {_identityService.GetUsername()}\n" +
                $"Request Method : {httpContext.Request?.Method}\n" +
                $"Host : {requestedHost}\n" +
                $"IP : {remoteIpResult}\n" +
                $"Controller : {httpContext.Request?.Path.Value}\n" +
                $"Body : {body}\n");

            httpContext.Request.Body.Position = 0L;

            await _next(httpContext);
        }
    }

    public static class SerilogCustomFieldMiddlewareExtension
    {
        public static void UseSerilogCustomField(this IApplicationBuilder app)
        {
            app.UseMiddleware<SerilogCustomFieldMiddleware>();
        }
    }
}

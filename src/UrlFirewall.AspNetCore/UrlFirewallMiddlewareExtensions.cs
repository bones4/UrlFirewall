using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace UrlFirewall.AspNetCore
{
    public static class UrlFirewallMiddlewareExtensions
    {
        public static IApplicationBuilder UseUrlFirewall(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UrlFirewallMiddleware>();
        }

        public static string GetClientIp(HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }
    }
}
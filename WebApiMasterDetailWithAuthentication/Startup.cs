using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiMasterDetailWithAuthentication.Providers;

[assembly: OwinStartup(typeof(WebApiMasterDetailWithAuthentication.Startup))]

namespace WebApiMasterDetailWithAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(5),
                Provider = new AppAuthorizationServerProvider()
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
        }
    }
}

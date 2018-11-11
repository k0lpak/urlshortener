using Microsoft.AspNetCore.Hosting;

namespace UrlShortener
{
    public class LambdaRun : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder.UseStartup<Startup>();
        }
    }
}

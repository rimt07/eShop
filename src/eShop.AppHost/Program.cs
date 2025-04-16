using eShop.AppHost;

using eShop.AppHost;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddOpenAIServices(configuration.GetSection("OpenAI"));
}

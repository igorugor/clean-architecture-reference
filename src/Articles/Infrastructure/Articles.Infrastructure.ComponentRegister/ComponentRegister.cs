using Articles.AppServices.Contexts.Articles.Repositories;
using Articles.AppServices.Contexts.Articles.Services;
using Articles.Infrastructure.DataAccess.Contexts.Articles.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Articles.Infrastructure.ComponentRegister;

public static class ComponentRegister
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services.AddScoped<IArticleService, ArticleService>();
        
        return services;
    }
    
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IArticleRepository, ArticleRepository>();
        
        return services;
    }
}
using Application.IServices;
using Application.Services.Journal;
using Application.Services.Trees;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITreeService, TreeService>();
        services.AddScoped<IJournalService, JournalService>();


        return services;
    }
}

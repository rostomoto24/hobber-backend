using Microsoft.Extensions.DependencyInjection;
using Hobber.Application.Auth;
using Hobber.Application.Categories;
using Hobber.Application.Courses;
using Hobber.Application.Me;
using Hobber.Application.Notifications;
using Hobber.Application.Search;

namespace Hobber.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<TokenIssuer>();
        services.AddScoped<RegisterHandler>();
        services.AddScoped<LoginHandler>();
        services.AddScoped<RefreshHandler>();
        services.AddScoped<LogoutHandler>();
        services.AddScoped<ForgotPasswordHandler>();
        services.AddScoped<ResetPasswordHandler>();

        services.AddScoped<GetMeHandler>();
        services.AddScoped<UpdateMeHandler>();
        services.AddScoped<SetInterestsHandler>();
        services.AddScoped<GetMyCoursesHandler>();

        services.AddScoped<GetCategoriesHandler>();

        services.AddScoped<ListCoursesHandler>();
        services.AddScoped<GetCourseHandler>();
        services.AddScoped<EnrollHandler>();
        services.AddScoped<UnenrollHandler>();

        services.AddScoped<SearchHandler>();
        services.AddScoped<GetUnreadCountHandler>();

        return services;
    }
}

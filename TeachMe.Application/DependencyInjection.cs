using Microsoft.Extensions.DependencyInjection;
using TeachMe.Application.Auth;
using TeachMe.Application.Categories;
using TeachMe.Application.Courses;
using TeachMe.Application.Me;
using TeachMe.Application.Notifications;
using TeachMe.Application.Search;

namespace TeachMe.Application;

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

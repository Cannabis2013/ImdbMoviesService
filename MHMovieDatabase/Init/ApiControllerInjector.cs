namespace MHMovieDatabase.Init;

public class ApiControllerInjector : IServicesInjector
{
    private readonly string _allowedOrigins;
    public static IServicesInjector Instance(string allowedOrigins) => new ApiControllerInjector(allowedOrigins);

    private ApiControllerInjector(string allowedOrigins) => _allowedOrigins = allowedOrigins;

    public void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(_allowedOrigins, policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });
    }
}
namespace MHMovieDatabase.Init;

public class AppBuilderConfiguration
{
    private readonly string _allowedOrigins;
    private readonly List<IServiceInjector> _injectors;

    public AppBuilderConfiguration(string allowedOrigins)
    {
        _allowedOrigins = allowedOrigins;
        _injectors = new();
    }

    public void Config(WebApplicationBuilder builder)
    {
        RegisterApiServices(builder);
        _injectors.ForEach(r => r.Inject(builder));
    }

    public void AddServiceInjector(IServiceInjector injector) => _injectors.Add(injector);

    private void RegisterApiServices(WebApplicationBuilder builder)
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
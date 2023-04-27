namespace MHMovieDatabase.Init;

public class AppBuilderConfiguration
{
    private readonly string _allowedOrigins;
    private readonly List<IServicesInjector> _injectors;

    public AppBuilderConfiguration(string allowedOrigins)
    {
        _allowedOrigins = allowedOrigins;
        _injectors = new();
    }

    public void Config(WebApplicationBuilder builder) => _injectors.ForEach(r => r.Inject(builder));

    public void AddServicesInjector(IServicesInjector injector) => _injectors.Add(injector);
}
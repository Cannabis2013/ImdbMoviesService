using MHMovieDatabase.IMDB.Database;
using MHMovieDatabase.Init;
using MHMovieDatabase.Shared.Database;

namespace MHMovieDatabase.IMDB.Injector;

public class ImdbInjector : IServicesInjector
{
    public static IServicesInjector Instance()
    {
        return new ImdbInjector();
    }

    private ImdbInjector()
    {
    }

    public void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDbConnectionDetails, MovieDbConnectionDetails>();
        builder.Services.AddScoped<IMovies, ImdbDatabaseContext>();
        builder.Services.AddDbContext<ImdbDatabaseContext>();
    }
}
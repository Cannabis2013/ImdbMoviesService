using MHMovieDatabase.IMDB.Injector;
using MHMovieDatabase.Init;

const string allowedOrigins = "_allowedOrigins";

var builderConfig = new AppBuilderConfiguration(allowedOrigins);
builderConfig.AddServicesInjector(ImdbInjector.Instance());
builderConfig.AddServicesInjector(ApiControllerInjector.Instance(allowedOrigins));
var appConfig = new WebApplicationWithRouting(allowedOrigins);

var builder = WebApplication.CreateBuilder();

builderConfig.Config(builder);

var app = builder.Build();

appConfig.Config(app);
app.Run();
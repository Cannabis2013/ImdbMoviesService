
namespace MHMovieDatabase.Init;

public class WebApplicationWithRouting
{
    private readonly string _allowedOrigins;

    public WebApplicationWithRouting(string allowedOrigins)
    {
        _allowedOrigins = allowedOrigins;
    }

    public void Config(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(_allowedOrigins);
        app.UseHttpsRedirection();
        app.UseRouting();
        SetupAuthorization(app);
        app.MapControllers();
    }

    private void SetupAuthorization(WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
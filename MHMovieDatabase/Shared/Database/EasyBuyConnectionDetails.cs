namespace MHMovieDatabase.Shared.Database;

public class MovieDbConnectionDetails : IDbConnectionDetails
{
    public MovieDbConnectionDetails(IConfiguration configuration) => _configuration = configuration;

    public string ConnectionString()
    {
        var pass = _configuration.GetValue<string>("password");
        var connectionString = BaseString + DbUserPart() + PasswordPart() + DatabasePart();
        return connectionString;
    }

    private string DbUserPart()
    {
        var userName = _configuration.GetValue<string>(UserVar);
        const string field = "user id=";
        return field + userName + ";";
    }

    private string PasswordPart()
    {
        var pass = _configuration.GetValue<string>(PassVar);
        const string field = ";password=";
        return field + pass + ";";
    }

    private string DatabasePart()
    {
        const string field = "database=";
        return field + DbVar + ";";
    }

    // Services
    private readonly IConfiguration _configuration;
    
    // Member variables
    private const string DbVar = "moviedb";
    private const string UserVar = "dbmovieuser";
    private const string PassVar = "dbmoviepass";
    private const string BaseString = "server=localhost;";
}
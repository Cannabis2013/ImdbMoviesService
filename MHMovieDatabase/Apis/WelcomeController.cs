using Microsoft.AspNetCore.Mvc;

namespace MHMovieDatabase.Apis;

[ApiController,Route("/")]
public class WelcomeController : Controller
{
    [HttpGet]
    public RedirectResult Welcome() => new("/swagger");
}
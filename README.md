# ImdbMoviesService

## Short description

Just wanted to be creative in another language than Java and Spring. I think the most important part with this excercise
is to understand the concept of pagination and deal with some of the difficulties that you may encounter when implementing this feature.

I used Blazors component virtualization for better render performance and experimented with mainly two strategies
when it came to fetch new movies. 

The first one is the one I'll call the automatic strategy where I gave Blazor the responsibility to fetch new items. That implementation gave some unwanted behaviour during the process. Some of the problems included duplicate items and some issues related to the order of items. I managed to resolve these issues but there are still some issues left. The persisting issue for now is the items at the bottom of the container. These won't show and Blazor seems to reload this section when scrolling to the bottom which scrolls the container up to a random spot. This approach needs a great amount of fiddling around to get it to work properly I think. I haven't researched on this issue as much as I wanted to so I don't really know what is best practice with this strategy. Surely, there must be one since other sites implements this way of pagination more or less successfull.  

The second, and the prefered one, was the manual way where the user has to fetch manually by buttons. Yes, for a lazy persepctive it is the most cumbersome but it is also the most robust one. No unwanted behaviours occured and it seems error prone. It just works, but for a users point of perspective it can be trivial to click through a large amount of rows if that was the case. Yes, I could add more buttons that fetches greater number of rows, but often the underlying data is dynamic in size, and I don't want to add buttons as the amount of data grows. But that is for another project.

The solution consists of a .NET 7 Web Application for the API part, and Blazor WebAssembly for the client part.  

## Requirements

- .NET 7
- MySQL
- Mono (If you are on a *nix based OS)

## Recommended editors

Jetbrains Rider
Visual Studio

### On MAC

Ehhh try XCode?

## Variables

- Database name: moviedb
- Db user: dbmovieuser
- Db pass: dbmoviepass

## Final message
Enjoy!

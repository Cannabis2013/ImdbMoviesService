# ImdbMoviesService

## Short description

Just wanted to be creative in another language than Java and Spring. I think the most important part with this excercise
is to understand the concept of pagination and deal with some of the difficulties that you may encounter when implementing this feature.

I used Blazors component virtualization for better render performance and experimented with mainly two strategies
when it came to fetch new movies. 

The first one is the one I'll call the automatic strategy where I gave Blazor the responsibility to fetch new items. That implementation gave some unwanted behaviour like duplicate items and some issues related to the order of items. 

The second, and the prefered one, was the manual way where the user has to fetch manually by buttons. Yes, for a lazy persepctive it is the most cumbersome but it is also the most robust one. No unwanted behaviours occured and it seems error prone.

The solution consists of a .NET 7 Web Application for the API part, and Blazor WebAssembly for the client part.  

## Requirements

.NET 7
MySQL

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

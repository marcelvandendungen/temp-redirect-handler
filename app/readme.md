## Authorization header lost after HTTP temporary redirect response
### Stackoverflow question [28564961][1]

This code I wrote to solve the issue where the Authorization header is removed from the redirected request after the `HttpClient` receives an HTTP 307 Temporary Redirect response.

The code disables the automatic redirect feature in the `HttpClient` and installs a `DelegatingHandler` to re-issue the request to the new URI with the same headers, properties and content.

To test this code, follow these steps (have .NET Core 1.1 installed):
* clone this repository
* from the first commandline, move to &lt;root>\app
* run `dotnet run http://localhost:5000`
* from the second commandline, move to &lt;root>\app
* run `dotnet run http://localhost:5001`
* from the third commandline, move to &lt;root>\client
* run `dotnet run http://localhost:5000/api/test/redirect`

Please note, I disabled the authentication code in the ASP.NET Core Web API to allow this code to run without an authentication server.


[1]: http://stackoverflow.com/a/42566541/18044
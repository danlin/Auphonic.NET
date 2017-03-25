# Auphonic.Net
Auphonic.Net is a .NET Library for the [Auphonic](https://auphonic.com) [API](https://auphonic.com/api-docs/).

## Usage
```csharp
string clientId = "Your Client ID";
string clientSecret = "Your Client Secret";
string username = "Your Username";
string password = "Your Password";

// Initialize Auphonic Client
Auphonic auphonic = new Auphonic(clientId, clientSecret);

// Authenticate with Username and Password
string accessToken = auphonic.Authenticate(username, password);

// Authenticate with Access Token
auphonic.Authenticate(accessToken);

// Retrieve Account Info
Account account = auphonic.GetAccountInfo();
```
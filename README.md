# Game000

This demo project hosts a simple chat server based on ASP.NET Core Razor Pages and SignalR.

## Rooms branch features

Each time the home page is opened a new chat room is created. The page shows a QR code that links to the mobile chat interface for that room. Scan the QR code with a smartphone or tablet to join the conversation.

The desktop page only displays messages while participants interact from their mobile device.

To run the server use `dotnet run` inside the `GameServer` folder. The application is served under `/Game000`.

## Building for Tizen

JavaScript assets are transpiled to ES5 during `dotnet publish` using Babel. Ensure that Node.js is installed and run:

```bash
dotnet publish -c Release -o out
```

The publish step will automatically install Node dependencies and produce JavaScript compatible with the Tizen browser in the `out` folder.

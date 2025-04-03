# NETCore.MailKit

[![NuGet](https://img.shields.io/nuget/v/Devity.NETCore.MailKit.svg)](https://nuget.org/packages/Devity.NETCore.MailKit)
[![MailKit](https://img.shields.io/badge/MailKit-4.11.0-orange)](https://github.com/jstedfast/MailKit)
[![license](https://img.shields.io/github/license/dkorecko/Devity.NETCore.MailKit.svg)](https://github.com/dkorecko/Devity.NETCore.MailKit/blob/master/LICENSE)
[![GitHub-Actions-Img](https://github.com/dkorecko/Devity.NETCore.MailKit/workflows/build/badge.svg)](https://github.com/dkorecko/Devity.NETCore.MailKit/actions)

MailKit extension to use with ASP.NET Core projects.

## Original and why fork

The original version of this library has been created by [myloveCc](https://github.com/myloveCc) and can be accessed [here](https://github.com/myloveCc/NETCore.MailKit).

I have been a user of this library for a few years. However, over the time as the library was not maintained, I managed to come across some bugs and I had to re-release the fixes myself for use on my own projects. Furthermore, the last push happened to be a vulnerability in the underyling MailKit library, so I decided to fork the project and continue maintaining it as it's still being used by thousands of projects.

# Install with NuGet

```
Install-Package Devity.NETCore.MailKit
```

# Install with .NET CLI

```
dotnet add package Devity.NETCore.MailKit
```

# Usage

## Add MailKit at start-up

```csharp
builder.Services.AddMailKit(optionBuilder =>
{
    optionBuilder.UseMailKit(new MailKitOptions()
    {
        // get options from sercets.json
        Server = Configuration["Server"],
        Port = Convert.ToInt32(Configuration["Port"]),
        SenderName = Configuration["SenderName"],
        SenderEmail = Configuration["SenderEmail"],

        // can be optional with no authentication
        Account = Configuration["Account"],
        Password = Configuration["Password"],

        // enable ssl or tls
        Security = true
    });
});
```

### Or

Program.cs

```csharp
var mailKitOptions = builder.Configuration.GetSection("Email").Get<MailKitOptions>();
builder.Services.AddMailKit(config => config.UseMailKit(mailKitOptions));
```

secrets.json/appsettings.json:

```json
{
  "Email": {
    "Server": "localhost",
    "Port": 25,
    "SenderName": "Test Name",
    "SenderEmail": "test@test.com"
    "Account": "username",
    "Password": "password",
    "Security": true
  }
}
```

## Use EmailService like

```csharp
public class HomeController : Controller
{
    private readonly IEmailService _emailService;

    public HomeController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public IActionResult Email()
    {
        ViewData["Message"] = "ASP.NET Core mvc send email example";

        _emailService.Send("xxxx@gmail.com", "ASP.NET Core mvc send email example", "Send from asp.net core mvc action");

        return View();
    }
}
```

# LICENSE

MIT

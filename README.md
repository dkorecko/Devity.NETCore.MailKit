# NETCore.MailKit

[![NuGet](https://img.shields.io/nuget/v/Devity.NETCore.MailKit.svg)](https://nuget.org/packages/Devity.NETCore.MailKit)
[![NETCore CLR](https://img.shields.io/badge/.NETCore%20Clr-3.1-brightgreen)](https://www.microsoft.com/net/core)
[![MailKit](https://img.shields.io/badge/MailKit-2.6.0-orange)](https://github.com/jstedfast/MailKit)
[![license](https://img.shields.io/github/license/dkorecko/Devity.NETCore.MailKit.svg)](https://github.com/dkorecko/Devity.NETCore.MailKit/blob/master/LICENSE)
[![GitHub-Actions-Img]](https://github.com/dkorecko/Devity.NETCore.MailKit/actions)

[GitHub-Actions-Img]:https://github.com/myloveCc/NETCore.MailKit/workflows/build/badge.svg

MailKit extension for asp.net core
# Install with nuget

```
Install-Package Devity.NETCore.MailKit
```

# Install with .NET CLI
```
dotnet add package Devity.NETCore.MailKit
```

# How to use

## Add MailKit in startup like 

```csharp

public void ConfigureServices(IServiceCollection services)
{
    // Add framework services.
    services.AddMvc();

    //Add MailKit
    services.AddMailKit(optionBuilder =>
    {
        optionBuilder.UseMailKit(new MailKitOptions()
        {
            //get options from sercets.json
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
}

```

## Use EmailService like 

```csharp
public class HomeController : Controller
{
    private readonly IEmailService _EmailService;

    public HomeController(IEmailService emailService)
    {
        _EmailService = emailService;
    }

    public IActionResult Email()
    {
        ViewData["Message"] = "ASP.NET Core mvc send email example";

        _EmailService.Send("xxxx@gmail.com", "ASP.NET Core mvc send email example", "Send from asp.net core mvc action");

        return View();
    }
}

```

# LICENSE

MIT

using Devity.NETCore.BlazorExample.Components;
using Devity.NETCore.MailKit.Extensions;
using Devity.NETCore.MailKit.Infrastructure.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var mailKitOptions = builder.Configuration.GetSection("Email").Get<MailKitOptions>();
builder.Services.AddMailKit(config => config.UseMailKit(mailKitOptions));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();

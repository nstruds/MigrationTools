using MigrationTools.Components;
using PnP.Core.Auth.Services.Builder.Configuration;
using PnP.Core.Services.Builder.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddPnPCore();
builder.Services.Configure<PnPCoreOptions>(builder.Configuration.GetSection("PnPCore"));
// Add the PnP Core SDK Authentication Providers
builder.Services.AddPnPCoreAuthentication();
// Add the PnP Core SDK Authentication Providers configuration from the appsettings.json file
builder.Services.Configure<PnPCoreAuthenticationOptions>(builder.Configuration.GetSection("PnPCore"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QrCodeGeneratorDemo.Services;
using QrCodeGeneratorDemo.Services.Interfaces;
using QrCodeGeneratorDemo;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IQrCodeService, QrCodeService>();
builder.Services.AddSingleton<App>();

using IHost host = builder.Build();
App app = host.Services.GetRequiredService<App>();
app.Run();
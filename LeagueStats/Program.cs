using LeagueStats.Discord.Services;
using LeagueStats.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.ConfigureEntityFramework();

builder.Services.AddHttpClient();
builder.RegisterConfigurations();
builder.Services.RegisterDependencies();
builder.Services.RegisterServices();

builder.Services.AddHostedService<DiscordBackgroundService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

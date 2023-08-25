using RichDomain.API.Settings.Configurations;
using RichDomain.API.Settings;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;


builder.Services.AddSettingsConfigurations(configuration);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("DfPolicy");
app.UseAuthorization();
app.MapControllers();
app.MigrateDatabase();
app.Run();

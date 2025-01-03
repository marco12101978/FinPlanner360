using FinPlanner360.Api.Configuration;
using FinPlanner360.Data.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);



builder
    .AddApiConfig()
    .AddCorsConfig()
    .AddSwaggerConfig()
    .AddDbContextConfig()
    .AddIdentityConfig()
    .AddAutoMapperConfig()
    .AddDependencyInjectionConfig();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwaggerConfig(apiVersionDescriptionProvider);

    app.UseCors("Development");
}
else
{
    app.UseCors("Production");

}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseDbMigrationHelper();

app.Run();
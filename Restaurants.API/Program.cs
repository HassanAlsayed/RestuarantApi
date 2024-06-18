using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Application.Extensions;
using Restaurants.API.Middleware;
using Restaurnats.Domain.Entities___Copy;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme,Id = "bearerAuth"}
                },
                []
                }
            });
        });

        builder.Services.AddAuthentication();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddInfrastruture(builder.Configuration);
        builder.Services.AddApplication();

        builder.Services.AddScoped<ErrorHandlingMiddelware>();

        
        var app = builder.Build();


        var scop = app.Services.CreateScope();
        var seeder = scop.ServiceProvider.GetRequiredService<IRestuarantSeeders>();
        await seeder.Seed();

        app.UseMiddleware<ErrorHandlingMiddelware>();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapGroup("api/identity").MapIdentityApi<User>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
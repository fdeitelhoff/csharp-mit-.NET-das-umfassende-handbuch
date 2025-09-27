using Microsoft.EntityFrameworkCore;
using WebApiProjekt;
using WebApiProjekt.Context;
using WebApiProjekt.Controllers;
using WebApiProjekt.Middlewares;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));

// EF Core: Datenbankanbindung (hier SQLite als Beispiel)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("UserDb"));

// Filter für DI registrieren
builder.Services.AddScoped<LogActionFilter>();

// Explizit Console-Logging aktivieren
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "JWT mit Bearer im Header eingeben",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
        },
        new string[] {}
    }});

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Use(async (context, next) =>
{
    Console.WriteLine("Anfrage erhalten");
    await next(); // weiter zur n�chsten Middleware
    Console.WriteLine("Antwort wird gesendet");
});

// Erstelle eine Route Group f�r /api/users
//var usersGroup = app.MapGroup("/api/users");

// F�ge einen Filter hinzu (z.B. Logging)
//usersGroup.AddEndpointFilter(async (context, next) =>
//{
//    Console.WriteLine($"Anfrage f�r: {context.HttpContext.Request.Path}");
//    return await next(context);
//});

// Definiere Endpunkte innerhalb der Gruppe
//usersGroup.MapGet("/", () => new[] { "Alice", "Bob", "Charlie" });
//usersGroup.MapPost("/", (CreateUserRequest user) => Results.Created("/", user));

// GET: Alle Benutzer abrufen
app.MapGet("/api/users", async (AppDbContext db) =>
{
    var users = await db.Users.ToListAsync();
    return Results.Ok(users);
});

// POST: Neuen Benutzer hinzuf�gen
app.MapPost("/api/users", async (AppDbContext db, User user) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/api/users/{user.Id}", user);
});

app.UseMiddleware<ZeitmessMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapUserEndpoints();

app.Run();


//public static class UserEndpoints
//{
//	public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
//    {
//        var group = routes.MapGroup("/api/User").WithTags(nameof(User));

//        group.MapGet("/", async (AppDbContext db) =>
//        {
//            return await db.Users.ToListAsync();
//        })
//        .WithName("GetAllUsers")
//        .WithOpenApi();

//        group.MapGet("/{id}", async Task<Results<Ok<User>, NotFound>> (int id, AppDbContext db) =>
//        {
//            return await db.Users.AsNoTracking()
//                .FirstOrDefaultAsync(model => model.Id == id)
//                is User model
//                    ? TypedResults.Ok(model)
//                    : TypedResults.NotFound();
//        })
//        .WithName("GetUserById")
//        .WithOpenApi();

//        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, User user, AppDbContext db) =>
//        {
//            var affected = await db.Users
//                .Where(model => model.Id == id)
//                .ExecuteUpdateAsync(setters => setters
//                  .SetProperty(m => m.Id, user.Id)
//                  .SetProperty(m => m.Name, user.Name)
//                  );
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("UpdateUser")
//        .WithOpenApi();

//        group.MapPost("/", async (User user, AppDbContext db) =>
//        {
//            db.Users.Add(user);
//            await db.SaveChangesAsync();
//            return TypedResults.Created($"/api/User/{user.Id}",user);
//        })
//        .WithName("CreateUser")
//        .WithOpenApi();

//        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, AppDbContext db) =>
//        {
//            var affected = await db.Users
//                .Where(model => model.Id == id)
//                .ExecuteDeleteAsync();
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("DeleteUser")
//        .WithOpenApi();
//    }
//}
using TodoWebApi.Services;
using TodoWebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<ILoginService, LoginService>();
builder.Services.AddSingleton<ITodoService, TodoService>();
builder.Services.AddSingleton<IUserService, UserService>();

var corsPolicyName = "corsapp";

builder.Services.AddCors(p =>
    p.AddPolicy(name: corsPolicyName, builder =>
    {
        builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
    })
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(corsPolicyName);

app.MapControllers();

app.Run();

using Middleware.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.Use(async (context, next) =>
{

    Console.WriteLine("Before...");

    await next.Invoke();

    Console.WriteLine("After...");
});


app.Use(async (context, next) =>
{

    Console.WriteLine("Before..");

    await next.Invoke();

    Console.WriteLine("After...");
});


app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();

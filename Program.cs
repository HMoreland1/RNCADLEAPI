using Microsoft.OpenApi.Models;
using RNCADLEAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "RNCADLE API",
        Description = "An ASP.NET Core Web API created to handle all CRUD operations pertaining to comments within the RNCADLE App. <br/>Instructions on how to use the UI may be found within each method's dropdown.<br/><A XML-LINK=\"LINK\" HREF=\"https://github.com/Plymouth-University/coursework_2022-HMoreland1\">GitHub</A>",

    });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "CommentMicroservice.xml");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using SchoolManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IStateProvider, BogusStateProvider>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint and the Swagger UI.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

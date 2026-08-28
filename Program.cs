var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger - כדי לבדוק את השרת בלי הלקוח
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

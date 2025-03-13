var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string email = "sannlynnhtun.ace@gmail.com";
builder.Services.AddFluentEmail(email)
    .AddSmtpSender("smtp.gmail.com", 587, email, "yfcs fwep ktpi etdm");

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

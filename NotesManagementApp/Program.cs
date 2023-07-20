using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NotesManagementApp.Models;
using NotesManagementApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<NotesStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(NotesStoreDatabaseSettings)));
builder.Services.AddSingleton<INotesStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<NotesStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("NotesStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<INotesService, NotesService>();

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

using DailyApp.Api.AutoMappers;
using DailyApp.Api.DataModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注入数据库上下文
builder.Services.AddDbContext<DailyDbContext>(m =>
{
    //m.UseSqlServer(builder.Configuration.GetConnectionString("Constr"));
    m.UseSqlite(builder.Configuration.GetConnectionString("SqliteConstr"));
});

//注入AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperSetting));

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

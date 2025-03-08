var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(m =>
{
    string path = AppContext.BaseDirectory + "Study.Api.xml";
    //AppContext.BaseDirectory
    //1、获取程序集冲突解决程序用于探测程序集的基目录的文件路径。
    //2、这是每个应用程序域的属性。它的值对应于当前应用程序域的 AppDomain.BaseDirectory 属性。
    m.IncludeXmlComments(path,true);//引入Xml,并显示出来
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

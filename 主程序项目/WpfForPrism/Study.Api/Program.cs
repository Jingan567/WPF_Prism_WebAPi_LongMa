var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(m =>
{
    string path = AppContext.BaseDirectory + "Study.Api.xml";
    //AppContext.BaseDirectory
    //1����ȡ���򼯳�ͻ�����������̽����򼯵Ļ�Ŀ¼���ļ�·����
    //2������ÿ��Ӧ�ó���������ԡ�����ֵ��Ӧ�ڵ�ǰӦ�ó������ AppDomain.BaseDirectory ���ԡ�
    m.IncludeXmlComments(path,true);//����Xml,����ʾ����
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

using Blogging.Extension;
using Blogging.Mapper;
using Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceExtensions.AddDbContext(builder.Services, builder);
ServiceExtensions.AddIdentity(builder.Services);

//DI 
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddAutoMapper(typeof(BlogProfile));


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

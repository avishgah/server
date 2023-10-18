using AutoMapper;
using Bll;
using Dal;
using Entity2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBikeDal, BikeDal>();
builder.Services.AddScoped<IBikeBll, BikeBll>();

builder.Services.AddScoped<IuserBll, UserBll>();
builder.Services.AddScoped<IUserDal, UserDal>();

builder.Services.AddScoped<IOpinionBll, OpinionBll>();
builder.Services.AddScoped<IOpinionDal, OpinionDal>();

builder.Services.AddScoped<IStattionBll, StationBll>();
builder.Services.AddScoped<IStationDal, StationDal>();

builder.Services.AddScoped<IOrderBll, OrderBll>();
builder.Services.AddScoped<IOrderDal, OrderDal>();

builder.Services.AddScoped<IOrderBikeBll, OrderBikeBll>();
builder.Services.AddScoped<IOrderBikeDal, OrderBikeDal>();

builder.Services.AddDbContext<BikeARContext>();
var config = new MapperConfiguration(m =>
  m.AddProfile(new MapProfile()));
IMapper map = config.CreateMapper();
builder.Services.AddSingleton(map);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:3000",
                                                  "http://www.contoso.com")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

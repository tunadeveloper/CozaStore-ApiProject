using CozaStore.BusinessLayer.Abstract;
using CozaStore.BusinessLayer.Concrete;
using CozaStore.DataAccessLayer.Abstract;
using CozaStore.DataAccessLayer.Context;
using CozaStore.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICategoryDAL, EfCategoryDAL>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IProductDAL, EfProductDAL>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<IFeatureDAL, EfFeatureDAL>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<IMessageDAL, EfMessageDAL>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddDbContext<ApiContext>();


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

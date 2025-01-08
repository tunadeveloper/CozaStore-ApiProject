using CozaStore.BusinessLayer.Abstract;
using CozaStore.BusinessLayer.Concrete;
using CozaStore.DataAccessLayer.Abstract;
using CozaStore.DataAccessLayer.Context;
using CozaStore.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddScoped<IFeatureDAL, EfFeatureDAL>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<ICategoryDAL, EfCategoryDAL>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IFeatureDAL, EfFeatureDAL>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<IMessageDAL, EfMessageDAL>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddDbContext<ApiContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
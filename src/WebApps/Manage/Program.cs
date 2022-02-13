using Manage.IServices;
using Manage.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(c =>
                c.BaseAddress = new Uri("http://localhost:5249"));
                //c.BaseAddress = new Uri(Configuration["ApiSettings:GatewayAddress"]));

var app = builder.Build();

//IConfiguration Configuration = app.Services.GetRequiredService<IConfiguration>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

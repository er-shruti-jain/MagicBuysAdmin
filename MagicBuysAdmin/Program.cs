using MagicBuysAdmin.Middleware;
using MagicBuysAdmin.Repository;
using MagicBuysAdmin.ServiceContracts;
using MagicBuysAdmin.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.Add( new ServiceDescriptor(
    typeof(IProductService),
    typeof(ProductService),
    ServiceLifetime.Transient
    ));

//builder.Services.AddTransient<AuthMiddleware>();

string connectionString = builder.Configuration.GetConnectionString("ProductDB").ToString();
builder.Services.AddDbContext<ProductDBContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

//app.UseMiddleware<Middlewaretemp>();

//app.Use(async (HttpContext context, RequestDelegate request) =>
//{
//    await context.Response.WriteAsync("welcome to project\n");
//    await request(context);


//});

//app.UseMiddleware<AuthMiddleware>();



//app.Run(async (HttpContext context) =>

//await context.Response.WriteAsync("welcome to project2")
//);




app.Run();

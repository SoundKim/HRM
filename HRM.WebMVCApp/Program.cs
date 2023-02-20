using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.Infrastructure.Data;
using HRM.Infrastructure.Repository;
using HRM.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Injecting DBContextfile here (DI)
builder.Services.AddDbContext<HRMDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("HrmDb"));
});

//DI for repositories
builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRepositoryAsync>();
builder.Services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
builder.Services.AddScoped<IJobRequirementRepositoryAsync, JobRequirementRepositoryAsync>();

//DI for Services
builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();
builder.Services.AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>();
builder.Services.AddScoped<IJobRequirementServiceAsync, JobRequirementServiceAsync>();

var app = builder.Build();

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

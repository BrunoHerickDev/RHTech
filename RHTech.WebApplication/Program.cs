using Microsoft.EntityFrameworkCore;
using RhTech.Core.Application.Interfaces;
using RhTech.Core.Application.Services;
using RhTech.Core.Domain.Interfaces;
using RHTech.Infra.Data;
using TechRecruiter.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();


builder.Services.AddDbContext<RhTechDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("RhTechConnection"), b => b.MigrationsAssembly("RHTech.WebApplication")));

builder.Services.AddScoped<ICandidatosRepository, CandidatosRepository>();
builder.Services.AddScoped<IVagasRepository, VagasRepository>();
builder.Services.AddScoped<IEmpresasRepository, EmpresasRepository>();

builder.Services.AddScoped<ICandidatosService, CandidatosService>();
//builder.Services.AddScoped<IVagasService, VagasService>();
builder.Services.AddScoped<IEmpresasService, EmpresasService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

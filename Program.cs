using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using proiect.Data;
using System.Security.Claims;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Pacienti");
    options.Conventions.AuthorizeFolder("/Programari");

    options.Conventions.AuthorizePage("/Reviews/Create");
    options.Conventions.AuthorizePage("/Reviews/Edit");
    options.Conventions.AuthorizePage("/Reviews/Delete");

    options.Conventions.AuthorizePage("/Doctori/Create");
    options.Conventions.AuthorizePage("/Doctori/Edit");
    options.Conventions.AuthorizePage("/Doctori/Delete");
});
builder.Services.AddDbContext<proiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("proiectContext") ?? throw new InvalidOperationException("Connection string 'proiectContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("proiectContext") ?? throw new InvalidOperationException("Connection string 'proiectContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.Configure<IdentityOptions>(options =>
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

using HobbyProject.services;
using HobbyRazorCLient.Security;
using RBAC.Security.Authentication;
using RBAC.Security.Authorisation;
using RBAC.Security.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add Hobby specific services to the container.
builder.Services.AddTransient<IAuthenticator, MyAuthenticator>();
builder.Services.AddTransient<IRoleProvider, MyRoleProvider>();
builder.Services.AddSingleton<SecurityContext>();
builder.Services.AddTransient<HobbyService>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

using ControleDeContatos.Data;
using ControleDeContatos.Helper;
using ControleDeContatos.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BancoContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddScoped<IEmail, Email>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly= true;
    o.Cookie.IsEssential= true;
});

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

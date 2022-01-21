using Microsoft.EntityFrameworkCore;
using Trial_3.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbString = builder.Configuration.GetConnectionString("SQLiteDB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(dbString));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
    app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePages();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
Trial_3.Data.SeedData.EnsurePopulated(app);
app.Run();

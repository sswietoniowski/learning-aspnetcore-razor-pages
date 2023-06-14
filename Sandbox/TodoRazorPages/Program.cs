using Dapper;
using Microsoft.EntityFrameworkCore;
using TodoRazorPages.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("TodoConnectionString")));
//builder.Services.AddScoped<ITodoRepository, TodoRepositoryEntityFramework>();
builder.Services.AddScoped<ITodoRepository, TodoRepositoryDapper>();

SqlMapper.AddTypeHandler(new DapperSqlGuidTypeHandler());
SqlMapper.RemoveTypeMap(typeof(Guid));
SqlMapper.RemoveTypeMap(typeof(Guid?));

builder.Services.AddRazorPages();

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

// apply pending migrations
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<TodoDbContext>();

dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();
//dbContext.Database.Migrate();

//if (dbContext.Database.GetPendingMigrations().Any())
//{
//    dbContext.Database.Migrate();
//}

app.Run();

using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//THIS CODE WAS MOVED TO EXTENSIONS:
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<DataContext>(opt =>
//{
//    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
//builder.Services.AddScoped<DbContext>(sp => sp.GetService<DataContext>());
//builder.Services.AddCors(opt => {
//    opt.AddPolicy("CorsPolicy", policy =>
//    {
//        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
//    });
//});
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));
//builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseDefaultFiles();
//app.UseStaticFiles();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try { 
    var context = services.GetRequiredService<DataContext>(); 
    context.Database.Migrate();
    await Seed.SeedData(context);
}
catch (Exception ex) {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error ocurred during migration");
}

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    // route non-api urls to index.html
//    endpoints.MapFallbackToFile("/index.html");
//});
app.Run();

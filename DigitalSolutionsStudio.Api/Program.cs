using DigitalSolutionsStudio.Api.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(9, 0, 1)));
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Development", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    //Retry logic is needed only for smooth expirience with docker-compose bat file.
    bool connected = false;
    TimeSpan delay = TimeSpan.FromSeconds(3); 

    while (!connected)
    {
        try
        {
            dbContext.Database.EnsureCreated(); 
            connected = true; 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Could not connect to the database. I guess docker compose havent finished its job.");
            Thread.Sleep(delay); 
        }
    }
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("Development");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

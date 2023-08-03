using AutoMapper;
using Mango.Services.Coupons.Api;
using Mango.Services.Coupons.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// SV: this is where I have added my Connection String. ASP.Net  builder will automatically get the connection string section in the AppSettings.json.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")) ;
});




// SV: Mapper here is used to map the Model Class to the Dto to be sent accross the Network.
IMapper mapper=  MappingConfig.RegisterMaps().CreateMapper();

// SV: builder.Services addsingleton here add the mapper to show the dependancy injection.
builder.Services.AddSingleton(mapper);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
ApplyMigration();
app.Run();


// SV: this will automatically update the db if there is any pending migration left to update the Database.
void ApplyMigration()
{
    using IServiceScope scope = app.Services.CreateScope();
    var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (_db.Database.GetPendingMigrations().Count() > 0)
    {
        _db.Database.Migrate();
    }
}

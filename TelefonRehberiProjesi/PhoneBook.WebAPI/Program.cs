using Microsoft.EntityFrameworkCore;
using NLog.Web;
using PhoneBook.Business.Interfaces;
using PhoneBook.Business.Services;
using PhoneBook.Business.Mappings;
using PhoneBook.Core.Interfaces;
using PhoneBook.DataAccess.Context;
using PhoneBook.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// --- NLog Ayarları ---
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// --- Veritabanı Ayarı ---
builder.Services.AddDbContext<PhoneBookDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- Bağımlılıkları Kaydediyoruz (Dependency Injection) ---
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IContactService, ContactService>();

// --- AutoMapper Kaydı ---
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger ayarları
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
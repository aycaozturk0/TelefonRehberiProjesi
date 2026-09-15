using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Entities;
namespace PhoneBook.DataAccess.Context;

public class PhoneBookDbContext : DbContext
{
    public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }
}
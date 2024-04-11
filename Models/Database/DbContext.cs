
using massimo.macaru._5i.FORMDotNetMVC.Models;
using Microsoft.EntityFrameworkCore;


public class dbContext : DbContext
{
    public dbContext(DbContextOptions<dbContext> options) 
        : base(options) 
    {
    }

    public DbSet<Carrello> Carrello { get; set; }
    public DbSet<Utente> Utente { get; set; } = default!;
}

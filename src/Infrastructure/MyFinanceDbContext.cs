using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Infrastructure
{
  public class MyFinanceDbContext : DbContext
  {
    public DbSet<PlanoConta> PlanoConta { get; set; }
    public DbSet<Transacao> Transacao { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var connStr = @"Server=localhost,1433\\Catalog=myfinance;Database=myfinance;User=sa;Password=SqlS1-Fin;TrustServerCertificate=True;";
      optionsBuilder.UseSqlServer(connStr);
    }
  }
}

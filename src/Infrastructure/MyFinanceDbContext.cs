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
      //Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;Password=myPassword;
      //var connStr = @"Server=localhost\sql1;Database=myfinance;User Id=sa;Password=SqlS1-Fin;";
      //var connStr = @"Server=localhost;Database=myfinance;User Id=sa;Password=SqlS1-Fin; Trusted_Connection=True; TrustServerCertificate=True; TrustServerCertificate=True";
      var connStr = @"Server=localhost,1433\\Catalog=myfinance;Database=myfinance;User=sa;Password=SqlS1-Fin;TrustServerCertificate=True;";
      optionsBuilder.UseSqlServer(connStr);
    }
  }
}
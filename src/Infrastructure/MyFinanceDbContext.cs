using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using DotEnv.Core;

namespace myfinance_web_netcore.Infrastructure
{
  public class MyFinanceDbContext : DbContext
  {
    public DbSet<PlanoConta> PlanoConta { get; set; }
    public DbSet<Transacao> Transacao { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var reader = new EnvLoader().AddEnvFile(".env").Load();
      string connStr = reader["CONNECTION_STRING"];
      optionsBuilder.UseSqlServer(connStr);
    }
  }
}

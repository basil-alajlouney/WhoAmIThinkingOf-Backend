using ContextMenu;
using Microsoft.EntityFrameworkCore;
namespace Connector;
public class ConnectionPoint : DbContext
{
    public DbSet<UserContext> Users {get;set;} = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlite("Filename=./connection/database.db");
    }
}
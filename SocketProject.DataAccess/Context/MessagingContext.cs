using Microsoft.EntityFrameworkCore;

namespace SocketProject.Api.Context
{
    public class MessagingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-R04PVQ3\\SQLEXPRESS; Database = DbPurchasing; Trusted_Connection = true; TrustServerCertificate = true;");
        }
    }
}

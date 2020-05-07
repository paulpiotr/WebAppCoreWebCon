using Microsoft.EntityFrameworkCore;

namespace WebAppCoreWebCon.Data
{
    public class Doradob2bContext : DbContext
    {
        public Doradob2bContext(DbContextOptions<Doradob2bContext> options)
            : base(options)
        {
        }

        public DbSet<DoradoB2BCoreContext.Models.Audit> Audit { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace nalys.Models
{
    public class svEntities : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-24T1NPF;Initial Catalog=SV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            );

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Class> Class { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace RF.Estudo.Infrastructure.Contexts
{
    public class EstudoContext : DbContext
    {
        public EstudoContext(DbContextOptions<EstudoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstudoContext).Assembly);
        }
    }
}

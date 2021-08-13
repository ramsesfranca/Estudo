using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            #region Configurações Básicas

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #endregion
        }
    }
}

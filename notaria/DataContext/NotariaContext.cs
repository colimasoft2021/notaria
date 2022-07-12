using Microsoft.EntityFrameworkCore;
using notaria.DataEntities;

namespace notaria.DataContext
{
    public class NotariaContext : DbContext
    {
        public NotariaContext(DbContextOptions<NotariaContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RolEntity> Rol { get; set; }
        public DbSet<EstatusEntity> Estatus { get; set; }
        public DbSet<TipoActoEntity> TipoActo { get; set; }
        public DbSet<ActoEntity> Acto { get; set; }
        public DbSet<PasoActoEntity> PasoActo { get; set; }
        public DbSet<TramiteEntity> Tramite { get; set; }
        public DbSet<TramitePasoEntity> TramitePaso { get; set; }
        public DbSet<ArchivoPasoTramiteEntity> ArchivoPasoTramite { get; set; }
        public DbSet<ArchivoTramiteEntity> ArchivoTramite { get; set; }
        //ResetPwd
        public DbSet<TokenEntity> Tokens { get; set; }
    }
}

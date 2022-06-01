using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model;

namespace Tasks.API.Data
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
                : base(options) { }

        #region Propriedades DbSets

        public DbSet<Tb_usuario> Tb_usuario { get; set; }
        public DbSet<Tb_workspace> Tb_workspace{ get; set; }
        public DbSet<Tb_userworkspace> Tb_userworkspace{ get; set; }
        public DbSet<Tb_bucket> Tb_bucket{ get; set; }
        public DbSet<Tb_etiqueta> Tb_etiqueta{ get; set; }
        public DbSet<Tb_status> Tb_status{ get; set; }
        public DbSet<Tb_task> Tb_task{ get; set; }
        public DbSet<Tb_etiquetatask> Tb_etiquetatask{ get; set; }
        public DbSet<Tb_anexo> Tb_anexo{ get; set; }
        public DbSet<Tb_usertotask> Tb_usertotask{ get; set; }
        public DbSet<Tb_checklist> Tb_checklist { get; set; }
        
        #endregion
    }
}

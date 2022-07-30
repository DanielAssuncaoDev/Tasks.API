using Microsoft.EntityFrameworkCore;
using Tasks.API.Data.Model;
using System.Linq;
using Tasks.API.Data.Model.Interfaces;
using System;

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
        public DbSet<Tb_itemchecklist> Tb_itemchecklist { get; set; }

        #endregion

        #region Métodos sobrepostos

        public override int SaveChanges()
        {
            FillStandardFields(EntityState.Added);
            FillStandardFields(EntityState.Modified);

            return base.SaveChanges();
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Método para preencher os campos padrão das tabelas (Dh_alteracao, Dh_inclusao)
        /// </summary>
        /// <param name="entityState">Tipo de ação que será executada na entidade</param>
        private void FillStandardFields(EntityState entityState)
        {
            // Detectando as mudanças realizadas nesse contexto.
            ChangeTracker.DetectChanges();

            // Recupera todas as entidades do contexto que estejam no mesmo estado passado por parâmetro
            var entries = ChangeTracker.Entries()
                        .Where(t => t.State == entityState)
                        .Select(t => t.Entity)
                        .ToArray();

            // Percorre cada entidade adicionando os valores padrão para cada operação
            foreach (var entity in entries)
            {
                if (!(entity is IColumnsDefault))
                    continue;

                var entityTable = entity as IColumnsDefault;
                if (entityState == EntityState.Added)
                {
                    entityTable.Dh_inclusao = DateTime.Now;
                    entityTable.Tg_inativo = false; 
                }

                if (entityState == EntityState.Modified)
                {
                    entityTable.Dh_alteracao = DateTime.Now;
                }
            }
        }

        #endregion


    }
}

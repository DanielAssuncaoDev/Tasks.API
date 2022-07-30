using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data
{
    public class Tb_task : ColumnsDefault, ITb_task
    {
        /// <summary>
        /// Título da task
        /// </summary>
        [Column(TypeName = "Varchar(125)")]
        public string Ds_task { get; set; }

        /// <summary>
        /// Descrição da Task
        /// </summary>
        public string Ds_descricao { get; set; }
        
        /// <summary>
        /// Bucket referênte a Task
        /// </summary>
        public int Fk_bucket { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o Bucket
        /// </summary>
        [ForeignKey("Fk_bucket")]
        public virtual Tb_bucket Bucket { get; set; }
        
        /// <summary>
        /// Usuário criador da Task
        /// </summary>
        public int Fk_owner { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o usuário criador
        /// </summary>
        [ForeignKey("Fk_owner")]
        public virtual Tb_usuario Owner { get; set; }

        /// <summary>
        /// Último usuário a alterar status da Task
        /// </summary>
        public int? Fk_useralteradorstatus { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o último usuário que alterou a Task
        /// </summary>
        [ForeignKey("Fk_useralteradorstatus")]
        public virtual Tb_usuario UserAlteradorStatus { get; set; }

        /// <summary>
        /// Status da Task
        /// </summary>
        public int Fk_status { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o Status da Task
        /// </summary>
        [ForeignKey("Fk_status")]
        public virtual Tb_status Status { get; set; }

        /// <summary>
        /// Posição da Task
        /// </summary>
        public int Nr_posicao { get; set; }
        
        /// <summary>
        /// Prazo para a Task estar marcada com o status de concluída
        /// </summary>
        public DateTime? Dh_prazo { get; set; }

        /// <summary>
        /// Flag que identifica se a Task foi Inativada por Inativação do Workspace
        /// </summary>
        public bool Tg_inativoporworkspace { get; set; }
    }
}

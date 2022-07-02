using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Model
{
    public class Tb_bucket : ColumnsDefault, ITb_bucket
    {
        /// <summary>
        /// Nome do Bucket
        /// </summary>
        [Column(TypeName = "Varchar(100)")]
        public string Ds_bucket { get; set; }
        
        /// <summary>
        /// Workspace referente ao Bucket
        /// </summary>
        public int Fk_workspace { get; set; }

        /// <summary>
        /// Objeto de relacionamento para o Workspace
        /// </summary>
        [ForeignKey("Fk_workspace")]
        public virtual Tb_workspace Workspace { get; set; }

        /// <summary>
        /// Posição em que reside o Bucket dentro do Workspace
        /// </summary>
        public int Nr_position { get; set; }

        /// <summary>
        /// Status referente ao Bucket
        /// </summary>
        public int? Fk_status { get; set; }

        /// <summary>
        /// Objeto de relacionamento com status
        /// </summary>
        [ForeignKey("Fk_status")]
        public Tb_status? Status { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations.Schema;
using Tasks.Data.Model.Interfaces;

namespace Tasks.Data.Model
{
    public class Tb_workspace : ColumnsDefault, ITb_workspace
    {
        /// <summary>
        /// Nome do Workspace
        /// </summary>
        [Column(TypeName = "Varchar(100)")]
        public string Ds_workspace { get; set ; }

        /// <summary>
        /// Id do usuário criador do Workspace
        /// </summary>
        public int Fk_owner { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o usuário criador do Workspace
        /// </summary>
        [ForeignKey("Fk_owner")]
        public virtual Tb_usuario Usuario { get; set; }
    }
}

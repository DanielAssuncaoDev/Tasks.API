using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Model
{
    public class Tb_etiqueta : ColumnsDefault, ITb_etiqueta
    {
        /// <summary>
        /// Descrição da etiqueta
        /// </summary>
        [Column(TypeName = "Varchar(50)")]
        public string Ds_etiqueta { get; set; }

        /// <summary>
        /// Código hexadecimal da cor da etiqueta
        /// </summary>
        [Column(TypeName = "Char(6)")]
        public string Ds_hex { get; set; }
        
        /// <summary>
        /// Workspace referenciado a etiqueta (Caso nula, significa que é referênte a todos os workspaces)
        /// </summary>
        public int? Fk_workspace { get; set; }

        /// <summary>
        /// Objeto de relacionamento com a etiqueta
        /// </summary>
        [ForeignKey("Fk_workspace")]
        public virtual Tb_workspace Workspace { get; set; }
    }
}

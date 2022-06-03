using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Model
{
    public class Tb_itemchecklist : ColumnsDefault, ITb_itemchecklist
    {
        /// <summary>
        /// Checklist que o item é referênte
        /// </summary>
        public int Fk_checklist { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o Checklist
        /// </summary>
        [ForeignKey("Fk_checklist")]
        public virtual Tb_checklist Checklist { get; set; }

        /// <summary>
        /// Descrição do item
        /// </summary>
        public string Ds_item { get; set; }
        
        /// <summary>
        /// Flag que marca se o item está concluído
        /// </summary>
        public bool Tg_concluido { get; set; }
    }
}

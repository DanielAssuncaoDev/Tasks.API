using System.ComponentModel.DataAnnotations.Schema;
using Tasks.Data.Model.Interfaces;

namespace Tasks.Data.Model
{
    public class Tb_etiquetatask : ColumnsDefault, ITb_etiquetatask
    {
        /// <summary>
        /// Etiqueta referênte a Task
        /// </summary>
        public int Fk_etiqueta { get; set; }

        /// <summary>
        /// Objeto de relacionamento com a etiqueta
        /// </summary>
        [ForeignKey("Fk_etiqueta")]
        public virtual Tb_etiqueta Etiqueta { get; set; }
        
        /// <summary>
        /// Task referenciada
        /// </summary>
        public int Fk_task { get; set; }

        /// <summary>
        /// Objeto de relacionamento com a Task
        /// </summary>
        [ForeignKey("Fk_task")]
        public virtual Tb_task Task { get; set; }
    }
}

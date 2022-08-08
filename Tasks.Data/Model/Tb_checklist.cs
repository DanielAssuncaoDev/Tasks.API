using System.ComponentModel.DataAnnotations.Schema;
using Tasks.Data.Model.Interfaces;

namespace Tasks.Data.Model
{
    public class Tb_checklist : ColumnsDefault, ITb_checklist
    {
        /// <summary>
        /// Descrição do Checklist
        /// </summary>
        [Column(TypeName = "Varchar(100)")]
        public string Ds_checklist { get; set; }

        /// <summary>
        /// Task em relacionada ao Checklist
        /// </summary>
        public int Fk_task { get; set; }

        /// <summary>
        /// Objeto de relacionamento com a Task
        /// </summary>
        [ForeignKey("Fk_task")]
        public virtual Tb_task Task { get; set; }
    }
}

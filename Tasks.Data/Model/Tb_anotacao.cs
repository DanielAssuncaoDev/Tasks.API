using System.ComponentModel.DataAnnotations.Schema;
using Tasks.Data.Model.Interfaces;

namespace Tasks.Data.Model
{
    public class Tb_anotacao : ColumnsDefault, ITb_anotacao
    {
        [Column(TypeName = "Text")]
        public string Ds_anotacao { get; set; }

        public int Fk_task { get; set; }

        [ForeignKey("Fk_task")]
        public Tb_task Task{ get; set; }

        public int Fk_owner { get; set; }

        [ForeignKey("Fk_owner")]
        public Tb_usuario User { get; set; }
    }
}

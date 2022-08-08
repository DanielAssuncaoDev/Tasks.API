using System.ComponentModel.DataAnnotations.Schema;
using Tasks.Data.Model.Interfaces;

namespace Tasks.Data.Model
{
    public class Tb_status : ColumnsDefault, ITb_status
    {
        /// <summary>
        /// Descrição do status
        /// </summary>
        [Column(TypeName = "Varchar(80)")]
        public string Ds_status { get; set; }

        /// <summary>
        /// Workspace referente ao status
        /// </summary>
        public int? Fk_workspace { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o Workspace
        /// </summary>
        [ForeignKey("Fk_workspace")]
        public virtual Tb_workspace Workspace{ get; set; }
        
        /// <summary>
        /// Identifica se o status é padrão do sistema ou foi criado por um usuário (true = Padrão | false = Criado por um usuário)
        /// </summary>
        public bool Tg_defaultsystem { get; set; }
    }
}

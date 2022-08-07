using System.ComponentModel.DataAnnotations.Schema;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Model
{
    public class Tb_integrante : ColumnsDefault, ITb_userworkspace
    {
        /// <summary>
        /// Usuário referente ao workspace
        /// </summary>
        public int Fk_user { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o usuário
        /// </summary>
        [ForeignKey("Fk_user")]
        public virtual Tb_usuario Usuario{ get; set; }

        /// <summary>
        /// Workspace referente ao usuário
        /// </summary>
        public int Fk_workspace { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o Workspace
        /// </summary>
        [ForeignKey("Fk_workspace")]
        public virtual Tb_workspace Workspace { get; set; }
    }
}

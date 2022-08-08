using System.ComponentModel.DataAnnotations.Schema;
using Tasks.Data.Model.Interfaces;

namespace Tasks.Data.Model
{
    public class Tb_anexo : ColumnsDefault, ITb_anexo
    {
        /// <summary>
        /// Path de onde está o arquivo
        /// </summary>
        public string Ds_path { get; set; }
     
        /// <summary>
        /// Tipo do arquivo
        /// </summary>
        [Column(TypeName = "Varchar(10)")]
        public string Ds_type { get; set; }

        /// <summary>
        /// Quantidade de bytes contidas do arquivo
        /// </summary>
        public int Qt_bytes { get; set; }

        /// <summary>
        /// Task referênte ao arquivo
        /// </summary>
        public int Fk_task { get; set; }

        /// <summary>
        /// Objeto de relacionamento com a Task
        /// </summary>
        [ForeignKey("Fk_task")]
        public virtual Tb_task Task { get; set; }

        /// <summary>
        /// Usuário que criou o arquivo
        /// </summary>
        public int Fk_owner { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o usuário criador do arquivo
        /// </summary>
        [ForeignKey("Fk_owner")]
        public virtual Tb_usuario UsuarioCriador { get; set; }
    }
}

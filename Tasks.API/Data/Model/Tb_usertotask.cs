using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Model
{
    public class Tb_usertotask : ColumnsDefault, ITb_usertotask
    {
        /// <summary>
        /// Usuário responsável pela Task
        /// </summary>
        public int Fk_user { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o usuário
        /// </summary>
        [ForeignKey("Fk_user")]
        public virtual Tb_usuario Usuario { get; set; }

        /// <summary>
        /// Task que o usuário é responsável
        /// </summary>
        public int Fk_task { get; set; }

        /// <summary>
        /// Objeto de relacionamento com a Task
        /// </summary>
        [ForeignKey("Fk_task")]
        public virtual Tb_task Task { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Model
{
    public class ColumnsDefault : IColumnsDefault
    {
        [Key]
        public int Pk_id { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime Dh_inclusao { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime? Dh_alteracao { get; set; }

        public bool Tg_inativo { get; set; }

    }
}

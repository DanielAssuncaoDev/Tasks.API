using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Model
{
    public class Tb_usuario : ColumnsDefault, ITb_usuario
    {
        [Column(TypeName = "Varchar(100)")]
        public string Ds_usuario { get; set; }

        [Column(TypeName = "Varchar(200)")]
        public string Ds_email { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string Hx_password { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Hx_refreshtoken { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime Dh_expirationrefreshtoken { get; set; }
    }
}

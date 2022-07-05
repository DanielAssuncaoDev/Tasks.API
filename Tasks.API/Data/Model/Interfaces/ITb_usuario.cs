using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    public interface ITb_usuario : IColumnsDefault
    {
        public string Ds_usuario { get; set; }
        public string Ds_email { get; set; }
        public string Hx_password { get; set; }
        public string Hx_refreshtoken { get; set; }
        public DateTime? Dh_expirationrefreshtoken { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    interface ITb_etiqueta : IColumnsDefault
    {
        public string Ds_etiqueta { get; set; }
        public string Ds_hex { get; set; }
        public int? Fk_workspace { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    interface ITb_anexo : IColumnsDefault
    {
        public string Ds_path { get; set; }
        public string Ds_type { get; set; }
        public int Qt_bytes { get; set; }
        public int Fk_task { get; set; }
        public int Fk_owner { get; set; }
    }
}

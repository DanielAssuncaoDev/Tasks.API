using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    interface ITb_etiquetatask : IColumnsDefault
    {
        public int Fk_etiqueta { get; set; }
        public int Fk_task { get; set; }
    }
}

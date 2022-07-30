using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    interface ITb_task : IColumnsDefault
    {
        public string Ds_task { get; set; }
        public string Ds_descricao { get; set; }
        public int Fk_bucket { get; set; }
        public int Fk_owner { get; set; }
        public int? Fk_useralteradorstatus { get; set; }
        public int Fk_status { get; set; }
        public int Nr_posicao { get; set; }
        public DateTime? Dh_prazo { get; set; }
        public bool Tg_inativoporworkspace { get; set; }
    }
}

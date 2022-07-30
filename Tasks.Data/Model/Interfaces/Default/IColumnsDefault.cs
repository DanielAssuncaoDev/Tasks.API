using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    public interface IColumnsDefault
    { 
        public int Pk_id { get; set; }
        public DateTime Dh_inclusao { get; set; }
        public DateTime? Dh_alteracao { get; set; }
        public bool Tg_inativo { get; set; }
    }
}

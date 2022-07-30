using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    interface ITb_status : IColumnsDefault
    {
        public string Ds_status { get; set; }
        public int? Fk_workspace { get; set; }
        public bool Tg_defaultsystem { get; set; }
    }
}

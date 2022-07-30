using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    interface ITb_workspace : IColumnsDefault
    {
        public string Ds_workspace { get; set; }
        public int Fk_owner { get; set; }
    }
}

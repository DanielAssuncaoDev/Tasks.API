using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    interface ITb_anotacao : IColumnsDefault
    {
        public string Ds_anotacao { get; set; }
        public int Fk_task { get; set; }
        public int Fk_owner { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    interface ITb_bucket : IColumnsDefault
    {
        public string Ds_bucket { get; set; }
        public int Fk_workspace { get; set; }
        public int Nr_position { get; set; }
        public int? Fk_status { get; set; }
    }
}

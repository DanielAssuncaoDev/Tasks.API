﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data.Model.Interfaces
{
    interface ITb_itemchecklist : IColumnsDefault
    {
        public int Fk_checklist { get; set; }
        public string Ds_item { get; set; }
        public bool Tg_concluido { get; set; }
    }
}

﻿namespace Tasks.Data.Model.Interfaces
{
    interface ITb_workspace : IColumnsDefault
    {
        public string Ds_workspace { get; set; }
        public int Fk_owner { get; set; }
    }
}

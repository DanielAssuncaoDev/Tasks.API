﻿namespace Tasks.Data.Model.Interfaces
{
    interface ITb_etiquetatask : IColumnsDefault
    {
        public int Fk_etiqueta { get; set; }
        public int Fk_task { get; set; }
    }
}

namespace Tasks.Data.Model.Interfaces
{
    interface ITb_etiqueta : IColumnsDefault
    {
        public string Ds_etiqueta { get; set; }
        public string Ds_hex { get; set; }
        public int? Fk_workspace { get; set; }
    }
}

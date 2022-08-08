namespace Tasks.Data.Model.Interfaces
{
    interface ITb_responsavelTask : IColumnsDefault
    {
        public int Fk_user { get; set; }
        public int Fk_task { get; set; }
    }
}

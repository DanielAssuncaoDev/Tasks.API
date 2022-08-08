namespace Tasks.Data.Model.Interfaces
{
    interface ITb_integrante : IColumnsDefault
    {
        public int Fk_user { get; set; }
        public int Fk_workspace { get; set; }
    }
}

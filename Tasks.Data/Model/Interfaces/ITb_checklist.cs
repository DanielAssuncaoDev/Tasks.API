namespace Tasks.Data.Model.Interfaces
{
    interface ITb_checklist : IColumnsDefault
    {
        public string Ds_checklist { get; set; }
        public int Fk_task { get; set; }
    }
}

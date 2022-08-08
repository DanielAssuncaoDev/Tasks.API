using Tasks.Data.Model.Interfaces;

namespace Tasks.Data.Model.Interfaces
{
    interface ITb_anotacao : IColumnsDefault
    {
        public string Ds_anotacao { get; set; }
        public int Fk_task { get; set; }
        public int Fk_owner { get; set; }
    }
}

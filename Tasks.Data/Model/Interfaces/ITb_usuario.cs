﻿using System;

namespace Tasks.API.Data.Model.Interfaces
{
    public interface ITb_usuario : IColumnsDefault
    {
        public string Ds_usuario { get; set; }
        public string Ds_email { get; set; }
        public string Hx_password { get; set; }
        public string Hx_refreshtoken { get; set; }
        public DateTime? Dh_expirationrefreshtoken { get; set; }
        public bool Tg_emailAtivo { get; set; }
        public int? Cd_ativacaoEmail { get; set; }

    }
}

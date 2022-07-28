using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Model
{
    public class Tb_usuario : ColumnsDefault, ITb_usuario
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        [Column(TypeName = "Varchar(100)")]
        public string Ds_usuario { get; set; }

        /// <summary>
        /// E-mail do usuário
        /// </summary>
        [Column(TypeName = "Varchar(200)")]
        public string Ds_email { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Column(TypeName = "Varchar(100)")]
        public string Hx_password { get; set; }

        /// <summary>
        /// Token para ser enviado caso o token padrão seja expirado
        /// </summary>
        [Column(TypeName = "Varchar(150)")]
        public string Hx_refreshtoken { get; set; }

        /// <summary>
        /// Data de expiração para o Refresh token
        /// </summary>
        [Column(TypeName = "Datetime")]
        public DateTime? Dh_expirationrefreshtoken { get; set; }

        /// <summary>
        /// Flag para controlar se o e-mail do usuário já foi ativado
        /// </summary>
        public bool Tg_emailAtivo { get; set; } = false;

        /// <summary>
        /// Código para a ativação do e-mail do usuário
        /// </summary>
        [Column(TypeName = "Numeric(6,0)")]
        public int? Cd_ativacaoEmail { get; set; }
    }
}

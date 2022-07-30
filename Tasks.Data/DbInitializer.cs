using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Data
{
    public static class DbInitializer
    {
        /// <summary>
        /// Inicializa Database e alimenta tabelas caso o mesmo não tenha sido criado na conexão específicada.
        /// </summary>
        /// <param name="context"> Contexto para database </param>
        public static void Initialize(SqlServerContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}

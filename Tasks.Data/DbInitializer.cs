namespace Tasks.Data
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

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tasks.API.Data.Model;
using Tasks.API.Data.Model.Interfaces;
using Tasks.API.Data.Repository.Interfaces.Default;

namespace Tasks.API.Data.Repository.Default
{
    public abstract class RepositoryDefault<TModel> : IRepositoryDefault<TModel>
        where TModel: ColumnsDefault 
    {
        /// <summary>
        /// Entidade utilizada
        /// </summary>
        protected readonly DbSet<TModel> _dataset;

        /// <summary>
        /// Contexto para fazer requisições no banco de dados
        /// </summary>
        protected readonly SqlServerContext _context;

        protected RepositoryDefault(SqlServerContext context)
        {
            _context = context;
            _dataset = context.Set<TModel>();
        }

        /// <summary>
        /// Alterar ativação para o valor oposto ao atual do registro passado por parâmetro.
        /// </summary>
        /// <param name="id">Id do registro a ser alterado</param>
        /// <returns>Retorna a atual situação do registro (true | false)</returns>
        public virtual bool ChangeActivation(int id)
        {
            var entityResult = GetById(id);
            entityResult.Tg_inativo = !entityResult.Tg_inativo;

            _context.SaveChanges();
            return entityResult.Tg_inativo;
        }

        /// <summary>
        /// Cria um registro do tipo específicado
        /// </summary>
        /// <param name="model">Objeto a ser criado</param>
        /// <returns>Id do registro criado</returns>
        public virtual int Create(TModel model)
        {
            _dataset.Add(model);
            _context.SaveChanges();

            return model.Pk_id;
        }

        /// <summary>
        /// Busca todos os registros da entidade específicada
        /// </summary>
        /// <returns>Os regitros da entidade</returns>
        public virtual IEnumerable<TModel> GetAll()
        {
            return _dataset;
        }

        /// <summary>
        /// Busca o registro cujo o id seja passado por parâmetro
        /// </summary>
        /// <param name="id">Id do registro que deseja ser buscado</param>
        /// <returns>O registro da entidade</returns>
        public virtual TModel GetById(int id)
        {
            return _dataset.FirstOrDefault(m => m.Pk_id == id);
        }

        public virtual TModel Update(TModel model, int id)
        {
            throw new NotImplementedException();
        }
    }
}

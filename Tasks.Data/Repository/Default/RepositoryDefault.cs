using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Tasks.API.Data.Model;
using Tasks.API.Data.Model.Interfaces;
using Tasks.API.Data.Repository.Interfaces.Default;

namespace Tasks.API.Data.Repository.Default
{
    public abstract class RepositoryDefault<TModel, TInterface> : IRepositoryDefault<TModel, TInterface>
        where TModel: ColumnsDefault 
        where TInterface: IColumnsDefault
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
        public virtual int Create(TInterface model)
        {
            if (!(model is TModel))
                throw new Exception("Interface incompatível com a entidade.");

            TModel entity = model as TModel;

            _dataset.Add(entity);
            _context.SaveChanges();

            return entity.Pk_id;
        }

        /// <summary>
        /// Busca todos os registros da entidade específicada
        /// </summary>
        /// <returns>Os regitros da entidade</returns>
        public virtual IQueryable<TModel> GetAll() =>
            _dataset;

        /// <summary>
        /// Busca o registro cujo o id seja passado por parâmetro
        /// </summary>
        /// <param name="id">Id do registro que deseja ser buscado</param>
        /// <returns>O registro da entidade</returns>
        public virtual TModel GetById(int id)
        {
            return _dataset.FirstOrDefault(m => m.Pk_id == id);
        }

        /// <summary>
        /// Altera uma entidade do tipo generico da classe
        /// </summary>
        /// <param name="model">Entidade que com os dados que devem ser alterados na base de dados</param>
        /// <param name="id">Id da entidade que deve ser alterada</param>
        /// <returns>A entidade já alterada</returns>
        public virtual TModel Update(TInterface model, int id)
        {
            var newModelProperties = model.GetType().GetProperties().ToList();
         
            var entityOld = GetById(id);
            var oldModelProperties = entityOld.GetType().GetProperties().ToList();
            var notCanUpdate = new ColumnsDefault().GetType().GetProperties().ToList();

            foreach (PropertyInfo propertyNew in newModelProperties) 
            {
                if (notCanUpdate.Any(x => x.Name.Equals(propertyNew.Name)))
                    continue;

                var propertyOld = oldModelProperties
                    .FirstOrDefault(x => x.Name.Equals(propertyNew.Name));
                if (propertyOld is null)
                    continue;

                propertyOld.SetValue(entityOld, propertyNew.GetValue(model));
            }

            _context.SaveChanges();
            return entityOld;
        }
    }
}

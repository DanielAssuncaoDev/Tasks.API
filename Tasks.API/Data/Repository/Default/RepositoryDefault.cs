using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tasks.API.Data.Model.Interfaces;
using Tasks.API.Data.Repository.Interfaces.Default;

namespace Tasks.API.Data.Repository.Default
{
    public abstract class RepositoryDefault<TModel> : IRepositoryDefault<TModel>
        where TModel: IColumnsDefault 
    {

        private readonly DbSet<TModel> _dataset;

        protected RepositoryDefault(SqlServerContext context)
        {
            _context = context;
        }


        public int Create(TModel model)
        {
            _context.TModel.Add(model);   
            return model.Pk_id;
        }

        public IEnumerable<TModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Inactivate(int id)
        {
            throw new NotImplementedException();
        }

        public TModel Update(TModel model, [Optional] int id)
        {
            throw new NotImplementedException();
        }
    }
}

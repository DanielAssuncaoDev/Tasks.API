using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Repository.Interfaces.Default
{
    public interface IRepositoryDefault <TModel, TInterface> 
        where TModel: IColumnsDefault
    {
        TModel GetById(int id);
        IEnumerable<TModel> GetAll();
        int Create(TInterface model);
        TModel Update(TInterface model, int id);
        bool ChangeActivation(int id);
    }
}

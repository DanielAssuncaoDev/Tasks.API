using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Repository.Interfaces.Default
{
    interface IRepositoryDefault <TModel> 
        where TModel: IColumnsDefault
    {
        TModel GetById(int id);
        IEnumerable<TModel> GetAll();
        int Create(TModel model);
        TModel Update(TModel model, [Optional] int id);
        bool Inactivate(int id);
    }
}

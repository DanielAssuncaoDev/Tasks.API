using System.Linq;
using Tasks.API.Data.Model.Interfaces;

namespace Tasks.API.Data.Repository.Interfaces.Default
{
    public interface IRepositoryDefault <TModel, TInterface> 
        where TModel: IColumnsDefault
    {
        TModel GetById(int id);
        IQueryable<TModel> GetAll();
        int Create(TInterface model);
        TModel Update(TInterface model, int id);
        bool ChangeActivation(int id);
    }
}

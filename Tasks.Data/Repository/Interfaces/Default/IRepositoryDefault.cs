using System.Linq;
using Tasks.Data.Model.Interfaces;

namespace Tasks.Data.Repository.Interfaces.Default
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data.Model;
using Tasks.API.Data.Repository.Interfaces.Default;

namespace Tasks.API.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepositoryDefault<Tb_usuario>
    {
    }
}

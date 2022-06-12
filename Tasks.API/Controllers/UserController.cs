using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data;
using Tasks.API.Data.Model;
using Tasks.API.Data.Repository.Interfaces;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository _userRepository { get; set; }

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tb_usuario>> ObterUsuarios() =>
                Ok(_userRepository.GetAll().ToList());


    }
}

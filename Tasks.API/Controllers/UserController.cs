using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Data;
using Tasks.API.Data.Model;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private SqlServerContext _context { get; set; }

        public UserController(SqlServerContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<List<Tb_usuario>> ObterUsuarios() =>
                Ok(_context.Tb_usuario.ToList());



    }
}

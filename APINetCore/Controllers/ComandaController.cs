using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APINetCore.Entidades;
using APINetCore.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINetCore.Controllers
{
    [ApiController]
    [Route("api/comanda")]
    public class ComandaController : ControllerBase
    {
        private readonly APIDbContext _DbContext;

        public ComandaController(APIDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        // api/comanda
        [HttpGet]
        public IActionResult Get()
        {
            var comanda = _DbContext.Comandas.ToList();

            return Ok(comanda);
        }

        // api/comanda/4
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var comanda = _DbContext.Comandas.SingleOrDefault(u => u.Id == id);

            if (comanda == null)
            {
                return NotFound();
            }

            return Ok(comanda);
        }

        // api/comanda
        [HttpPost]
        public IActionResult Post([FromBody] Comanda comanda)
        {
            var comanda = new Comanda(DateTime.Now);
            //_DbContext.Professores.Add(professor);
            //_DbContext.SaveChanges();

            //_DbContext.Alunos.Add(aluno);
            //_DbContext.SaveChanges();

            return NoContent();
        }

        // api/comanda/4
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        // api/comanda/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}

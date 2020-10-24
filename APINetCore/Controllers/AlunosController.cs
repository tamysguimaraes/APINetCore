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
    [Route("api/alunos")]
    public class AlunosController : ControllerBase
    {
        private readonly APIDbContext _DbContext;
        public AlunosController(APIDbContext awesomeDbContext)
        {
            _DbContext = awesomeDbContext;
        }
        // api/alunos
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _DbContext.Alunos.ToList();

            return Ok(alunos);
        }

        // api/alunos/4
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = _DbContext.Alunos.SingleOrDefault(u => u.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // api/alunos
        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno)
        {
            var professor = new Professor("professor 1", "endereco 1 ", aluno.IdUnidade);
            _DbContext.Professores.Add(professor);
            _DbContext.SaveChanges();

            _DbContext.Alunos.Add(aluno);
            _DbContext.SaveChanges();

            return NoContent();
        }

        // api/alunos/4
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        // api/alunos/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}

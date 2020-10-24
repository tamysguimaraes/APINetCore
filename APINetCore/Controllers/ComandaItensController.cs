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
    [Route("api/comandaitens")]
    public class ComandaItensController : ControllerBase
    {
        private readonly APIDbContext _DbContext;

        public ComandaItensController(APIDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        // api/comandaitens
        [HttpGet]
        public IActionResult Get()
        {
            var comandaItens = _DbContext.ComandaItens.ToList();

            return Ok(comandaItens);
        }

        // api/comandaitens/4
        [HttpGet("{idComanda}")]
        public IActionResult Get(int id)
        {
            var comandaItens = _DbContext.ComandaItens.SingleOrDefault(u => u.IdComanda == id);

            if (comandaItens == null)
            {
                return NotFound();
            }

            return Ok(comandaItens);
        }

        // api/comandaitens
        [HttpPost]
        public IActionResult Post(int idComanda,int idProduto,int qtde)
        {
            var comandaItem = new ItensComanda(idComanda, idProduto, qtde);
            _DbContext.ComandaItens.Add(comandaItem);
            _DbContext.SaveChanges();

            return NoContent();
        }

        // api/comandaitens/4
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        // api/comandaitens/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}

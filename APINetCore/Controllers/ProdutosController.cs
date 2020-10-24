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
    [Route("api/produto")]
    
    public class ProdutosController : ControllerBase
    {
        private readonly APIDbContext _DbContext;
        public ProdutosController(APIDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        // api/produto
        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _DbContext.Produtos.ToList();

            return Ok(produtos);
        }

        // api/produto/4
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produtos = _DbContext.Produtos.SingleOrDefault(u => u.Id == id);

            if (produtos == null)
            {
                return NotFound();
            }

            return Ok(produtos);
        }

        // api/produto
        [HttpPost]
        public IActionResult Post([FromBody] Produtos produtos)
        {
            _DbContext.Produtos.Add(produtos);
            _DbContext.SaveChanges();

            return NoContent();
        }

        // api/produto/4
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        // api/produto/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AS_FINAL.Data.Repositories;
using projeto.Domain.Interfaces;
using AS_FINAL.Domain;

namespace projeto.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroRepository repositiory;

        public LivrosController()
        {
            this.repositiory = new LivroRepository();
        }

        [HttpGet]
        public IEnumerable<Livro>Get()
        {
            return repositiory.GetAll();
        }
        [HttpGet("{id}")]
        public Livro Get(int id)
        {
            return repositiory.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Livro item)
        {
            repositiory.Save(item);
            return Ok( new {
                statusCode=200,
                message = "Cadastrado com sucesso",
                item
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repositiory.Delete(id);
            return Ok( new {
                statusCode=200,
                message = "lIVRO excluído com sucesso"
            });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Livro item)
        {
            repositiory.Update(item);
            return Ok( new {
                statusCode=200,
                message = item.Titulo + " atualizado com sucesso",
                item
            });
        }
    }
}
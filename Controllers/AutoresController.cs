using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AS_FINAL.Data.Repositories;
using projeto.Domain.Interfaces;
using AS_FINAL.Domain;

namespace AS_FINAL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresRepository : ControllerBase
    {
        private readonly IAutorRepository repositiory;

        public AutoresRepository()
        {
            this.repositiory = new AutorRepository();
        }

        [HttpGet]
        public IEnumerable<Autor>Get()
        {
            return repositiory.GetAll();
        }
        [HttpGet("{id}")]
        public Autor Get(int id)
        {
            return repositiory.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Autor item)
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
                message = "Autor excluído com sucesso"
            });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Autor item)
        {
            repositiory.Update(item);
            return Ok( new {
                statusCode=200,
                message = item.Nome + " atualizado com sucesso",
                item
            });
        }
    }
}

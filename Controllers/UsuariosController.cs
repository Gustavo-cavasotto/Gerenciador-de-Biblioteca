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
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository repositiory;

        public UsuariosController()
        {
            this.repositiory = new UsuarioRepository();
        }

        [HttpGet]
        public IEnumerable<Usuario>Get()
        {
            return repositiory.GetAll();
        }
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return repositiory.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Usuario item)
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
                message = "Usuário excluído com sucesso"
            });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Usuario item)
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
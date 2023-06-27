using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_FINAL.Domain;

namespace AS_FINAL.Models
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public ICollection<AutorDTO> Autores { get; set; }
    }
}
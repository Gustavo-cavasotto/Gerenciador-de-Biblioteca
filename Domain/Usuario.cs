using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_FINAL.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Livro> LivrosEmprestados { get; set; }
    }
}
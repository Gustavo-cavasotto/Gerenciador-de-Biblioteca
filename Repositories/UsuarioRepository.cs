using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_FINAL.Data.Repositories;
using AS_FINAL.Domain;
using Microsoft.EntityFrameworkCore;
using projeto.Data.Repositories;

namespace projeto.Domain.Interfaces
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext context;

        public UsuarioRepository()
        {
            this.context = new DataContext();
        }

        public void Delete(int entityId)
        {
            var ap = GetById(entityId);
            context.Usuarios.Remove(ap);
            context.SaveChanges();
        }

        public IList<Usuario> GetAll(){
            return context.Usuarios.ToList();
        }

        public Usuario GetById(int entityId)
        {
            return context.Usuarios.Include(x => x.LivrosEmprestados).SingleOrDefault(x => x.Id == entityId);
        }

        public void Save(Usuario entity)
        {
            context.Usuarios.Add(entity);
            context.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
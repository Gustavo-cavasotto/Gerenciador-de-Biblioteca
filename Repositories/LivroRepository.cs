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
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext context;

        
        public LivroRepository(){
            this.context = new DataContext();
        }

        public void Delete(int entityId)
        {
            var ap = GetById(entityId);
            context.Livros.Remove(ap);
            context.SaveChanges();
        }

        public IList<Livro> GetAll(){
            return context.Livros.ToList();
        }

        public Livro GetById(int entityId)
        {
            return context.Livros.Include(x => x.Autores).SingleOrDefault(x => x.Id == entityId);
        }

        public void Save(Livro entity)
        {
            context.Livros.Add(entity);
            context.SaveChanges();
        }

        public void Update(Livro entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
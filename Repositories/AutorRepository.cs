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
    public class AutorRepository : IAutorRepository
    {
        private readonly DataContext context;

        public AutorRepository()
        {
            this.context = new DataContext();
        }

        public void Delete(int entityId)
        {
            var ap = GetById(entityId);
            context.Autores.Remove(ap);
            context.SaveChanges();
        }

        public IList<Autor> GetAll()
        {
            return context.Autores.ToList();
        }

        public Autor GetById(int entityId)
        {
            return context.Autores.SingleOrDefault(x => x.Id == entityId);
        }

        public void Save(Autor entity)
        {
            context.Autores.Add(entity);
            context.SaveChanges();
        }

        public void Update(Autor entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
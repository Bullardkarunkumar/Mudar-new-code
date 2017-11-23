using MudarDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudarService.Repository
{
    public class MudarRepository
    {
        private MudarDBContext db;
        public MudarRepository()
        {
            db = new MudarDBContext();
        }
        
        public IQueryable<T> GetDetails<T>() where T : class
        {
            return db.Set<T>().AsQueryable<T>();
        }

        public int Save<T>(T entity) where T : class
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        
    }
}
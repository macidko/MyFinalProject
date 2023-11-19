using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //bir class'ı newlediğinde garbage collector belirli bir zamanda gelir ve atar.
            //using içerisinde yazılan nesneler using bittiğinde garbage collector'a gelir.
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                //karşısına hangi veri tipi gelirse onu tutan değişken anahtarı.
                var addedEntity = context.Entry(entity);
                //State = durum;
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //karşısına hangi veri tipi gelirse onu tutan değişken anahtarı.
                var deletedEntity = context.Entry(entity);
                //State = durum;
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //karşısına hangi veri tipi gelirse onu tutan değişken anahtarı.
                var updatedEntity = context.Entry(entity);
                //State = durum;
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}


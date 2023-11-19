using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        //LINQ Expression predicate
        //generic constraint
        //: class - referans tip olabilir demektir.
        //IEntity- IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
        //new() - newlenebilir olmalı.

        List<T> GetAll(Expression<Func<T, bool>> filter=null); //Hepsini getir.

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

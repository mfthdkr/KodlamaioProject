using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    // generic constraint: "where T: class" , burada class : referans tip anlamında
    // IEntity: IEntity olabilir veya IEntity implemente eden nesne olabilir
    // new() : somut bir nesne olmalıdır.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {       
        // filter veya predicate olarak geçer.
        // filter = null : filtre verilmezse bütün datayı getir.
        List<T> GetAll(Expression<Func<T,bool>>filter =null);

        //  filter zorunlu
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

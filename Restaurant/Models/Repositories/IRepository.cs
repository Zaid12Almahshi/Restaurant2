using System.Collections.Generic;

namespace Restaurant.Models.Repositories
{
    public interface IRepository<TEntity>
    {
        IList<TEntity> View();
        IList<TEntity> ViewFrontClinet();

        void Add(TEntity entity);

        void Delete(int Id,TEntity entity);
        void Update(int Id,TEntity entity);

        void Active(int Id,TEntity entity);
        TEntity Find(int id);

    }
}

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        public TransactionBookTableRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, TransactionBookTable entity)
        {
            //entity = Find(Id);
            if (entity.IsActive == false)
            {
                entity.IsActive = true;
            }
            else if (entity.IsActive == true)
            {
                entity.IsActive = false;
            }
            Db.TransactionBookTables.Update(entity);
            Db.SaveChanges();
        }

        public void Add(TransactionBookTable entity)
        {
            Db.TransactionBookTables.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, TransactionBookTable entity)
        {
            //entity = Find(Id);
            entity.IsDelete = true;
            Db.TransactionBookTables.Update(entity);
            Db.SaveChanges();
        }

        public TransactionBookTable Find(int id)
        {
            var data = Db.TransactionBookTables.SingleOrDefault(x => x.TransactionBookTableId == id);
            return data;
        }

        public void Update(int Id, TransactionBookTable entity)
        {
            Db.TransactionBookTables.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionBookTable> View()
        {
            return Db.TransactionBookTables.Where(x => x.IsDelete == false ).ToList();
        }

        public IList<TransactionBookTable> ViewFrontClinet()
        {
            return Db.TransactionBookTables.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}

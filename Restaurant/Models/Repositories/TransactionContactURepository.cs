using Microsoft.EntityFrameworkCore.ChangeTracking;
using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class TransactionContactURepository : IRepository<TransactionContactU>
    {
        public TransactionContactURepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, TransactionContactU entity)
        {
           // entity = Find(Id);
            if (entity.IsActive==false)
            {
                entity.IsActive = true;
            }else if (entity.IsActive == true)
            {
                entity.IsActive = false;
            }
            Db.TransactionContactUs.Update(entity);
            Db.SaveChanges();
        }

        public void Add(TransactionContactU entity)
        {
           Db.TransactionContactUs.Add(entity);
            Db.SaveChanges() ;
        }

        public void Delete(int Id, TransactionContactU entity)
        {
           // entity=Find(Id);    
            entity.IsDelete= true;
            Db.TransactionContactUs.Update(entity);
            Db.SaveChanges();
        }

        public TransactionContactU Find(int id)
        {
            var data=Db.TransactionContactUs.SingleOrDefault(x=>x.TransactionContactUId==id);
            return data;
        }

        public void Update(int Id, TransactionContactU entity)
        {
            Db.TransactionContactUs.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionContactU> View()
        {
            return Db.TransactionContactUs.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<TransactionContactU> ViewFrontClinet()
        {
            return Db.TransactionContactUs.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}

using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        public TransactionNewsletterRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, TransactionNewsletter entity)
        {
           // entity = Find(Id);
            if (entity.IsActive==false)
            {
                entity.IsActive = true;

            }
           else if (entity.IsActive==true)
            {
                entity.IsActive = false;
            }
            Db.TransactionNewsletters.Add(entity);
            Db.SaveChanges();
        }

        public void Add(TransactionNewsletter entity)
        {
            Db.TransactionNewsletters.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, TransactionNewsletter entity)
        {
           // entity = Find(Id);
            entity.IsDelete = true;
            Db.TransactionNewsletters.Update(entity);
            Db.SaveChanges();
        }

        public TransactionNewsletter Find(int id)
        {
            var data =Db.TransactionNewsletters.SingleOrDefault(x=>x.TransactionNewsletterId== id);
            return data;
        }

        public void Update(int Id, TransactionNewsletter entity)
        {
            Db.TransactionNewsletters.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionNewsletter> View()
        {
           return Db.TransactionNewsletters.Where(x=>x.IsDelete== false).ToList();
        }

        public IList<TransactionNewsletter> ViewFrontClinet()
        {
            return Db.TransactionNewsletters.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}

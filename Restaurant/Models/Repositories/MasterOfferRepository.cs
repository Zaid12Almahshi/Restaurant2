using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {
        public MasterOfferRepository(AppDbcontext _db) 
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, MasterOffer entity)
        {
            //entity = Find(Id);
            if (entity.IsActive==true)
            {
                entity.IsActive = false;
            }
            else if(entity.IsActive==false)
            {
                entity.IsActive = true;
            }
            Db.MasterOffers.Update(entity);
            Db.SaveChanges();
                
        }
        

        public void Add(MasterOffer entity)
        {
           Db.MasterOffers.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterOffer entity)
        {
            //entity = Find(Id);
            entity.IsDelete= true;
            Db.MasterOffers.Update(entity);
            Db.SaveChanges();
        }

        public MasterOffer Find(int id)
        {
           var data=Db.MasterOffers.SingleOrDefault(x=>x.MasterOfferId==id);
            return data;
        }

        public void Update(int Id, MasterOffer entity)
        {
            Db.MasterOffers.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterOffer> View()
        {
            return Db.MasterOffers.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<MasterOffer> ViewFrontClinet()
        {
            return Db.MasterOffers.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}

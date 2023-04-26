using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {
        public MasterPartnerRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, MasterPartner entity)
        {
            //entity = Find(Id);
            if (entity.IsActive==true)
            {
                entity.IsActive = false;
            }
            else if (entity.IsActive==false)
            {
                entity.IsActive = true;
            }
            Db.MasterPartners.Update(entity);
            Db.SaveChanges();
        }

        public void Add(MasterPartner entity)
        {
           Db.MasterPartners.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterPartner entity)
        {
            //entity = Find(Id);
            entity.IsDelete = true;
            Db.MasterPartners.Update(entity);
            Db.SaveChanges();
        }

        public MasterPartner Find(int id)
        {
            var data=Db.MasterPartners.SingleOrDefault(x=>x.MasterPartnerId==id);
            return data;
        }

        public void Update(int Id, MasterPartner entity)
        {
            Db.MasterPartners.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterPartner> View()
        {
            return Db.MasterPartners.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterPartner> ViewFrontClinet()
        {
            return Db.MasterPartners.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}

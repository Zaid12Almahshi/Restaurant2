using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterServiceRepository : IRepository<MasterService>
    {
        public MasterServiceRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, MasterService entity)
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
            Db.MasterServices.Update(entity);
            Db.SaveChanges();
        }

        public void Add(MasterService entity)
        {
           Db.MasterServices.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterService entity)
        {
           // entity=Find(Id);
            entity.IsDelete= true;
            Db.MasterServices.Update(entity);
            Db.SaveChanges();
        }

        public MasterService Find(int id)
        {
           var data =Db.MasterServices.SingleOrDefault(x=>x.MasterServiceId== id);
            return data;
        }

        public void Update(int Id, MasterService entity)
        {
            Db.MasterServices.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterService> View()
        {
            return Db.MasterServices.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<MasterService> ViewFrontClinet()
        {
            return Db.MasterServices.Where(x=>x.IsActive==true&&x.IsDelete== false).ToList();
        }
    }
}

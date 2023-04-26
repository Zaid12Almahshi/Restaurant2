using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterWorkingHourRepository : IRepository<MasterWorkingHour>
    {
        public MasterWorkingHourRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, MasterWorkingHour entity)
        {
           // entity = Find(Id);
            if (entity.IsActive==false)
            {
                entity.IsActive = true;
            }else if (entity.IsActive == true)
            {
                entity.IsActive = false;
            }
            Db.MasterWorkingHours.Update(entity);
            Db.SaveChanges();
        }

        public void Add(MasterWorkingHour entity)
        {
            Db.MasterWorkingHours.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterWorkingHour entity)
        {
           // entity = Find(Id);
            entity.IsDelete = true;
            Db.MasterWorkingHours.Update(entity);
            Db.SaveChanges();
        }


        public MasterWorkingHour Find(int id)
        {
            var data=Db.MasterWorkingHours.SingleOrDefault(x=>x.MasterWorkingHourId==id);
            return data;
        }

        public void Update(int Id, MasterWorkingHour entity)
        {
            Db.MasterWorkingHours.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterWorkingHour> View()
        {
            return Db.MasterWorkingHours.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<MasterWorkingHour> ViewFrontClinet()
        {
            return Db.MasterWorkingHours.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}

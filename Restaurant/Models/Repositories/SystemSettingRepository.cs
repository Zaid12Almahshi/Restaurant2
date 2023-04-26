using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class SystemSettingRepository : IRepository<SystemSetting>
    {
        public SystemSettingRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, SystemSetting entity)
        {
           // entity = Find(Id);
            if (entity.IsActive == false)
            {
                entity.IsActive = true;
            }
            else if (entity.IsActive == true)
            {
                entity.IsActive = false;
            }
            Db.SystemSettings.Update(entity);
            Db.SaveChanges();
        }

        public void Add(SystemSetting entity)
        {
            Db.SystemSettings.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, SystemSetting entity)
        {
           // entity = Find(Id);
            entity.IsDelete = true;
            Db.SystemSettings.Update(entity);
            Db.SaveChanges();
        }

        public SystemSetting Find(int id)
        {
            var data=Db.SystemSettings.SingleOrDefault(x=>x.SystemSettingId==id);
            return data;
        }

        public void Update(int Id, SystemSetting entity)
        {
            Db.SystemSettings.Update(entity);
            Db.SaveChanges();
        }

        public IList<SystemSetting> View()
        {
            return Db.SystemSettings.Where(x => x.IsDelete == false ).ToList();
        }

        public IList<SystemSetting> ViewFrontClinet()
        {
            return Db.SystemSettings.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}

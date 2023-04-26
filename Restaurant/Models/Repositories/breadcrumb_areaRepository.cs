using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class breadcrumb_areaRepository : IRepository<breadcrumb_area>
    {
        public AppDbcontext Db { get; }

        public breadcrumb_areaRepository(AppDbcontext _db )
        {
            Db = _db;
        }


        public void Active(int Id, breadcrumb_area entity)
        {
            if (entity.IsActive == false)
            {
                entity.IsActive = true;
            }
            else if (entity.IsActive == true)
            {
                entity.IsActive = false;
            }
            Db.breadcrumb_area.Update(entity);
            Db.SaveChanges();
        }

        public void Add(breadcrumb_area entity)
        {
            Db.breadcrumb_area.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, breadcrumb_area entity)
        {
            var breadcrumb_area = Db.breadcrumb_area.Find(Id);
            entity.IsDelete = true;
            Db.breadcrumb_area.Update(breadcrumb_area);
            Db.SaveChanges();
        }

        public breadcrumb_area Find(int id)
        {
            var data = Db.breadcrumb_area.SingleOrDefault(x => x.breadcrumb_areaId == id);
            return data;
        }

        public void Update(int Id, breadcrumb_area entity)
        {
            Db.breadcrumb_area.Update(entity);
            Db.SaveChanges();
        }

        public IList<breadcrumb_area> View()
        {
            return Db.breadcrumb_area.Where(x => x.IsDelete == false).ToList();
        }

        public IList<breadcrumb_area> ViewFrontClinet()
        {
            return Db.breadcrumb_area.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}

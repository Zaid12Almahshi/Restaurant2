using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        public MasterItemMenuRepository(AppDbcontext _db) 
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, MasterItemMenu entity)
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
            Db.MasterItemMenus.Update(entity);
            Db.SaveChanges();
        }

        public void Add(MasterItemMenu entity)
        {
            Db.MasterItemMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterItemMenu entity)
        {
            //entity = Find(Id);
            entity.IsDelete= true;
            Db.MasterItemMenus.Update(entity);
            Db.SaveChanges();
        }

        public MasterItemMenu Find(int id)
        {
            var data = Db.MasterItemMenus.Include(x => x.MasterCategoryMenu).SingleOrDefault(x => x.MasterItemMenuId == id);
            return data;

        }

        public void Update(int Id, MasterItemMenu entity)
        {
            Db.MasterItemMenus.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterItemMenu> View()
        {
            return Db.MasterItemMenus.Include(x=>x.MasterCategoryMenu).Where(x=>x.IsDelete==false).ToList();
        }

        public IList<MasterItemMenu> ViewFrontClinet()
        {
            return Db.MasterItemMenus.Include(x=>x.MasterCategoryMenu).Where(x=>x.IsActive==true&&x.IsDelete== false).ToList();  
        }
    }
}

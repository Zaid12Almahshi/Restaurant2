using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        public MasterMenuRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, MasterMenu entity)
        {
            //entity = Find(Id);
            if(entity.IsActive==true)
            {
                entity.IsActive = false;
            }
            else if (entity.IsActive==false)
            {
                entity.IsActive = true;
            }
            Db.MasterMenus.Update(entity);
            Db.SaveChanges();
        }

        public void Add(MasterMenu entity)
        {
            Db.MasterMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterMenu entity)
        {
            //entity = Find(Id);
            entity.IsDelete= true;
            Db.MasterMenus.Update(entity);
            Db.SaveChanges();
        }

        public MasterMenu Find(int id)
        {
            var data=Db.MasterMenus.SingleOrDefault(x=>x.MasterMenuId==id);
            return data;
        }

        public void Update(int Id, MasterMenu entity)
        {
            Db.MasterMenus.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterMenu> View()
        {
            return Db.MasterMenus.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<MasterMenu> ViewFrontClinet()
        {
            return Db.MasterMenus.Where(x=>x.IsActive==true&&x.IsDelete== false).ToList();  
        }
    }
}

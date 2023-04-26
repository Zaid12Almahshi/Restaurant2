using Microsoft.EntityFrameworkCore.Internal;
using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Restaurant.Models.Repositories
{
    public class MasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {
        public AppDbcontext Db { get; }
        public MasterCategoryMenuRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        

        public void Active(int Id, MasterCategoryMenu entity)
        {
            //entity = Find(Id);
            
            if(entity.IsActive== false)
            {
                entity.IsActive = true;   
            }
            else if(entity.IsActive== true)
            {
                entity.IsActive = false;
            }
            Db.MasterCategoryMenus.Update(entity);
            Db.SaveChanges();

        }

        public void Add(MasterCategoryMenu entity)
        {
            Db.MasterCategoryMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterCategoryMenu entity)
        {
            //entity = Find(Id);
            var MasterCategoryMenu = Db.MasterCategoryMenus.Find(Id);
            entity.IsDelete = true;   
            Db.MasterCategoryMenus.Update(MasterCategoryMenu);
            Db.SaveChanges();


        }

        public void Update(int Id, MasterCategoryMenu entity)
        {
           Db.MasterCategoryMenus.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterCategoryMenu> View()
        {
            return Db.MasterCategoryMenus.Where(x =>x.IsDelete== false).ToList();
        }

        public IList<MasterCategoryMenu> ViewFrontClinet()
        {
            return Db.MasterCategoryMenus.Where(x=>x.IsActive==true&&x.IsDelete== false).ToList();
        }

        public MasterCategoryMenu Find(int id)
        {
            var data= Db.MasterCategoryMenus.SingleOrDefault(x=>x.MasterCategoryMenuId==id);
            return data;
        }
    }
}

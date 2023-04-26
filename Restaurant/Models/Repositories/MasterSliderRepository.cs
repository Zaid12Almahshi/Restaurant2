using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Restaurant.Models.Repositories
{
    public class MasterSliderRepository : IRepository<MasterSlider>
    {
        public MasterSliderRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, MasterSlider entity)
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
            Db.MasterSliders.Update(entity);
            Db.SaveChanges();
        }

        public void Add(MasterSlider entity)
        {
            Db.MasterSliders.Add(entity);
            Db.SaveChanges() ;
        }

        public void Delete(int Id, MasterSlider entity)
        {
           // entity = Find(Id);
            entity.IsDelete = true;
            Db.MasterSliders.Update(entity);
            Db.SaveChanges() ;
        }

        public MasterSlider Find(int id)
        {
            var data=Db.MasterSliders.SingleOrDefault(x=>x.MasterSliderId==id); 
            return data;
        }

        public void Update(int Id, MasterSlider entity)
        {
            Db.MasterSliders.Update(entity);
            Db.SaveChanges() ;
        }

        public IList<MasterSlider> View()
        {
           return Db.MasterSliders.Where(x=>x.IsDelete==false).ToList();

        }

        public IList<MasterSlider> ViewFrontClinet()
        {
            return Db.MasterSliders.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}

using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterSocialMediumRepository : IRepository<MasterSocialMedium>
    {
        public MasterSocialMediumRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, MasterSocialMedium entity)
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
            Db.MasterSocialMedia.Update(entity);
            Db.SaveChanges();
        }

        public void Add(MasterSocialMedium entity)
        {
           Db.MasterSocialMedia.Add(entity);
            Db.SaveChanges() ;
        }

        public void Delete(int Id, MasterSocialMedium entity)
        {
           // entity=Find(Id);
            entity.IsDelete = true;
            Db.MasterSocialMedia.Update(entity);
            Db.SaveChanges() ;
        }

        public MasterSocialMedium Find(int id)
        {
            var data=Db.MasterSocialMedia.SingleOrDefault(x=>x.MasterSocialMediumId==id);   
            return data;
        }

        public void Update(int Id, MasterSocialMedium entity)
        {
            Db.MasterSocialMedia.Update(entity);
            Db.SaveChanges() ;  
        }

        public IList<MasterSocialMedium> View()
        {
            return Db.MasterSocialMedia.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<MasterSocialMedium> ViewFrontClinet()
        {
            return Db.MasterSocialMedia.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}

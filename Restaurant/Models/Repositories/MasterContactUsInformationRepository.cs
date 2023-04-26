using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {
        public MasterContactUsInformationRepository(AppDbcontext _db)
        {
            Db = _db;
        }

        public AppDbcontext Db { get; }

        public void Active(int Id, MasterContactUsInformation entity)
        {
            //entity = Find(Id);
            if (entity.IsActive == true)
            {
                entity.IsActive = false;
               

            }
            else if(entity.IsActive == false)
            {
                entity.IsActive = true;
            }
            Db.MasterContactUsInformations.Update(entity);
            Db.SaveChanges();

        }
       
       

        public void Add(MasterContactUsInformation entity)
        {
            Db.MasterContactUsInformations.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterContactUsInformation entity)
        {
            //entity = Find(Id);
            entity.IsDelete = true;
            Db.MasterContactUsInformations.Update(entity);
            Db.SaveChanges();
        }

        public MasterContactUsInformation Find(int id)
        {
           var data=Db.MasterContactUsInformations.SingleOrDefault(x=>x.MasterContactUsInformationId== id);
            return data;
        }

        public void Update(int Id, MasterContactUsInformation entity)
        {
            Db.MasterContactUsInformations.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterContactUsInformation> View()
        {
            return Db.MasterContactUsInformations.Where(x=>x.IsDelete== false).ToList();
        }

        public IList<MasterContactUsInformation> ViewFrontClinet()
        {
            return Db.MasterContactUsInformations.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}

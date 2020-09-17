using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Repository
{
    public class roomrep : Iroomrep

    {
        HMSDbContext db;
        public roomrep(HMSDbContext _db)
        {
            db = _db;
        }
        public int AddDetail(room Room)
        {
            db.rooms.Add(Room);
            db.SaveChanges();
            return Room.RoomNo;
        }

        public int Delete(int id)
        {
            int result = 0;
            if (db != null)
            {
                var post = db.rooms.FirstOrDefault(x => x.RoomNo == id);
                if (post != null)
                {
                    db.rooms.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }

        public room GetDetail(int id)
        {
            if (db != null)
            {
                return (db.rooms.Where(x => x.RoomNo == id)).FirstOrDefault();
            }
            return null;
        }

        public List<room> GetDetails()
        {
            return db.rooms.ToList();
        }
    }
}

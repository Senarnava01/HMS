using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Repository
{
    public class userrep : Iuserrep
    {
        HMSDbContext db;
        public userrep(HMSDbContext _db)
        {
            db = _db;
        }
        public string AddDetail(user boarder)
        {
            db.users.Add(boarder);
            db.SaveChanges();
            return boarder.Emailid;
        }

        public int Delete(string id)
        {
            int result = 0;
            if (db != null)
            {
                var post = db.users.FirstOrDefault(x => x.Emailid == id);
                if (post != null)
                {
                    db.users.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }

        public user GetDetail(string id)
        {
            if (db != null)
            {
                return (db.users.Where(x => x.Emailid == id)).FirstOrDefault();
            }
            return null;
        }

        public List<user> GetDetails()
        {
            return db.users.ToList();
        }

        public int UpdateDetail(string id, user boarder)
        {
            if (db != null)
            {
                var obj = (db.users.Where(x => x.Emailid == id)).FirstOrDefault();
                if (obj != null)
                {
                    obj.FirstName = boarder.FirstName;
                    obj.LastName = boarder.LastName;
                    //obj.Email = boarder.Email;
                    obj.Password = boarder.Password;
                    db.SaveChanges();
                    return 1;
                }
            }
            return 0;
        }
    }
}

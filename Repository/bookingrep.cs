using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Repository
{
    public class bookingrep : Ibookingrep
    {
        HMSDbContext db;
        public bookingrep(HMSDbContext _db)
        {
            db = _db;
        }
        public int AddDetail(booking Booking)
        {
            db.bookings.Add(Booking);
            db.SaveChanges();
            return Booking.BookingNo;
        }

        public int Delete(int id)
        {
            int result = 0;
            if (db != null)
            {
                var post = db.bookings.FirstOrDefault(x => x.BookingNo == id);
                if (post != null)
                {
                    db.bookings.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }

        public booking GetDetail(int id)
        {
            if (db != null)
            {
                return (db.bookings.Where(x => x.BookingNo == id)).FirstOrDefault();
            }
            return null;
        }

        public List<booking> GetDetails()
        {
            return db.bookings.ToList();
        }
    

    
    }
}

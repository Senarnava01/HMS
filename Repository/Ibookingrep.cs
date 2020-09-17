using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Repository
{
   public interface Ibookingrep
    {
        public List<booking> GetDetails();
        public booking GetDetail(int id);
        public int AddDetail(booking Booking);
        public int Delete(int id);
    }
}

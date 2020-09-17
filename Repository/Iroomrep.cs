using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Repository
{
   public interface Iroomrep
    {
        public List<room> GetDetails();
        public room GetDetail(int id);
        public int AddDetail(room Room);
        public int Delete(int id);
    }
}

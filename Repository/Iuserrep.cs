using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Repository
{
    public interface Iuserrep
    {
        public List<user> GetDetails();
        public user GetDetail(string id);
        public string AddDetail(user boarder);
        public int UpdateDetail(string id,  user boarder);
        public int Delete(string id);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class room
    {
        [Key]
        public int RoomNo { get; set; }
        public string RoomType { get; set; }
        public int 
           Tarrif{ get; set; }
    }
}

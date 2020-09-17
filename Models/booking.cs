using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class booking
    {
        [Key]
        public int BookingNo { get; set; }
        public string Emailid { get; set; }
        public int RoomNo { get; set; }
    }
}

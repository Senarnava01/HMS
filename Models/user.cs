using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class user
   
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            [Key]
            public string Emailid { get; set; }
            public string Password { get; set; }

            
        }
    }



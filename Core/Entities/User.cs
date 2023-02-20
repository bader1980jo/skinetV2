using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class User
    {
        [Key]
        public int Id {get ; set;}
        public string Name {get ; set;}
        public string UserName {get ; set;}
        public string Email {get ; set;}
        public string Password {get ; set;}
    }
}
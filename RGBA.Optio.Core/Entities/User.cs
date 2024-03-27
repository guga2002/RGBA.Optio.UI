using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Core.Entities
{
    [Table("Users")]
    public class User:IdentityUser
    {
        [Column("User_Name")]
        public string? Name { get; set; }

        [Column("User_Surname")]
        public string? Surname { get; set; }

        [Column("User_BirthDay")]
        public DateTime BirthDate { get; set; }
    }
}

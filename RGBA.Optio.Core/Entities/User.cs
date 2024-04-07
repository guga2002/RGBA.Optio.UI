using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(50,ErrorMessage = "this name is not allowed",MinimumLength =2)]
        public required string Name { get; set; }


        [Column("User_Surname")]
        [StringLength(100, ErrorMessage = "this surname is not allowed", MinimumLength = 4)]
        public required string Surname { get; set; }


        [Column("User_BirthDay")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}

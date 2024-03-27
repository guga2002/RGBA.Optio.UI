using Optio.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGBA.Optio.Core.Entities
{
    [Table("ValutesCourses")]
    public class ValuteCourse:AbstractClass
    {
        public string ValuteName { get; set; }

        public float Amount { get; set; }

        public DateTime dateOfValuteCourse { get; set; }
    }
}

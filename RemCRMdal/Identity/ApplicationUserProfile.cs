using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.Identity
{
    public class ApplicationUserProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Midlename { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

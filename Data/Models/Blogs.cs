using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Blogs
    {
        [Key]
        public string BlogID { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; } 
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.Now;
        [ForeignKey("userId")]
        public string UserId { get; set; }   = Guid.NewGuid().ToString();
        public ApplicationUser User { get; set; }
    }
}

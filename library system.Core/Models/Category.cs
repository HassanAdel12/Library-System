using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system.Core.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name for Category is required")]
        [StringLength(200, MinimumLength = 2)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Description for Category is required")]
        [StringLength(300, MinimumLength = 2)]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}

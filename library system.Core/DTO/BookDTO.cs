using library_system.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system.Core.DTO
{
    public class BookDTO
    {

        public int BookId { get; set; }

        [Required(ErrorMessage = "Name for Book is required")]
        [StringLength(200, MinimumLength = 2)]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Description for Book is required")]
        [StringLength(300, MinimumLength = 2)]
        public string Description { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Price must be non-negative")]
        public float Price { get; set; }

        public string Auther { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "stock must be non-negative")]
        public int stock { get; set; }

        public int CategoryId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Add title property")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int ISBN { get; set; }
        public string BookAuthor { get; set; }
        public int Pages { get; set; }
        public int Price { get; set; }
        public int quantity { get; set; }
        public string DatePublished { get; set; }
        public string DateUploaded { get; set; }
        public string LastUpdated { get; set; }
        public bool IsInStore { get; set; }
    }
}

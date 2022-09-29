using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class Books
    {
        public int Id { get; set; }
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

namespace BookStore.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int ISBN { get; set; }
        public string bookAuthor { get; set; }
        public int Price { get; set; }
        public int quantity { get; set; }
        public int Total { get; set; }
        public string DatePurchased { get; set; }
    }
}

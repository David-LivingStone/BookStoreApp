namespace BookStore.Models
{
    public class LendingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ISBN { get; set; }
        public int DefaultFee { get; set; }
        public string DateCollected { get; set; }
        public string DueDate { get; set; }
    }
}

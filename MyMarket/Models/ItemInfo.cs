namespace MyMarket.Models
{
    public class ItemInfo
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string Title { get; set; }

        public string Value { get; set; }

        public Item? Item { get; set; }
    }
}

namespace MyMarket.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Rating { get; set; }

        public int Price { get; set; }

        public string? Img { get; set; }

        public int FactoryId { get; set; }

        public int TypeId { get; set; }

        public string? Description { get; set; }

        public List<ItemInfo>? ItemInfo { get; set; }

       // public virtual Factory? Factory { get; set; }

       // public virtual TypeItem? TypeItem { get; set; }
    }
}

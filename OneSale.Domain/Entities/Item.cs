using OneSale.Domain.ValueObjects;

namespace OneSale.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public Quantity Quantity { get; private set; }
        public decimal DiscountedPrice { get; private set; }

        public Item(Product product, Quantity quantity, decimal discountedPrice)
        {
            Id = Guid.NewGuid();
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
            DiscountedPrice = discountedPrice;
        }

        public Item() { }
    }
}

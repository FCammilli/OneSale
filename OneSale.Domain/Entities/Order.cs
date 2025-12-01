namespace OneSale.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public User User { get; set; }
        public List<Item> Items { get; private set; }
        public decimal Total { get; private set; }

        public Order(Guid id, User user, List<Item> items, decimal total)
        {
            Id = id;
            User = user ?? throw new ArgumentNullException(nameof(user));
            Items = items ?? throw new ArgumentNullException(nameof(items));
            Total = total;
        }
        public Order() { }
    }
}

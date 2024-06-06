namespace eShopping.Basket.Application
{
    public class ShoppingCartDto(string userName)
    {
        public string Username { get; init; } = userName;
        public List<ShoppingCartItemDto> Items { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }

                return totalPrice;
            }
        }
    }

    public class ShoppingCartItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImageFile { get; set; }
    }
}
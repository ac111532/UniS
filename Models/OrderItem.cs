using System.ComponentModel.DataAnnotations;
using UniS.Models;

public class OrderItem
{
    public int OrderItem_ID { get; set; }

    [Required(ErrorMessage = "Order ID is required")]
    public int Order_ID { get; set; }

    [Required(ErrorMessage = "Product ID is required")]
    public int Product_ID { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }

    public Product Product { get; set; }
    public Order Order { get; set; }

    // Additional validation rules could be added here
}
using System.ComponentModel.DataAnnotations;

namespace UniS.Models
{
    public class Product
    {
        public int Product_ID { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Product description is required")]
        public string Product_Description { get; set; }

        [Required(ErrorMessage = "Product size is required")]
        public string Product_Size { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Product price must be a positive number")]
        public decimal Product_Price { get; set; }

        [Required(ErrorMessage = "Product stock is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Product stock must be a positive integer")]
        public int Product_Stock { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        // Additional validation rules could be added here

    }
} 
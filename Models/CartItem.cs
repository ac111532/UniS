using System.ComponentModel.DataAnnotations;

namespace UniS.Models
{
    public class CartItem
    {
        public int Cart_Item_ID { get; set; }

        [Required(ErrorMessage = "Cart ID is required")]
        public int Cart_ID { get; set; }

        [Required(ErrorMessage = "Product ID is required")]
        public int? Product_ID { get; set; }

        [Required(ErrorMessage = "Cart quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Cart quantity must be a positive integer")]
        public int Cart_Quantity { get; set; }

        // Additional validation rules could be added here

    }
}
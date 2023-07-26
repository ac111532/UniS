    using System.ComponentModel.DataAnnotations;

    namespace UniS.Models
    {
        public class CartItem
        {
            public int CartItemID { get; set; }

            [Required(ErrorMessage = "Cart ID is required")]
            public int CartID { get; set; }

            [Required(ErrorMessage = "Product ID is required")]
            public int? ProductID { get; set; }

            [Required(ErrorMessage = "Cart quantity is required")]
            [Range(1, int.MaxValue, ErrorMessage = "Cart quantity must be a positive integer")]
            public int CartQuantity { get; set; }

            // Additional validation rules could be added here

        }
    }
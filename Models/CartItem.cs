    using System.ComponentModel.DataAnnotations;

    namespace UniS.Models
    {
        public class CartItem
        {
            public int CartItemID { get; set; }
            public int OrderID { get; set; }

            [Display(Name = "Product Name")]
            [Required(ErrorMessage = "Product ID is required")]
            public int? ProductID { get; set; }

            [Display(Name = "Product Name")]
            public int CartQuantity { get; set; }

            public Product Product { get; set; }
            public Order Order { get; set; }

            // Additional validation rules could be added here

        }
    }
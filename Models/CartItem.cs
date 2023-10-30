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

            // The model here is used for creating a cart item, which a product is turned into before being added to an order. Makes a customers cart Viewable.

        }
    }
using System.ComponentModel.DataAnnotations;

namespace UniS.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product description is required")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Product size is required")]
        public string ProductSize { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Product price must be a positive number")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Product stock is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Product stock must be a positive integer")]
        public int ProductStock { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        // Additional validation rules could be added here

    }
}

/* 
Custom datatype

Public enum XXX
{
    X,X,X
}

then

Public XX XX { get; set; }
*/
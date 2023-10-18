using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string fileName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile imageFile { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

        // Additional validation rules could be added hereS

    }
}
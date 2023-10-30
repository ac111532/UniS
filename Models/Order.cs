using System.ComponentModel.DataAnnotations;


namespace UniS.Models
{
    public enum Status
    {
        Incomplete,
        Processing,
        Finalised
    }
    public class Order
    {
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }

        public string CustomerID { get; set; }
        
        [Display(Name = "Customer")]
        public string CustomerName { get; set; }


        [DataType(DataType.DateTime)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Scheduled Pick up date")]
        public DateTime PickupDate { get; set; }

        [Display(Name = "Order Progress")]
        public Status OrderStatus { get; set; }

        [Display(Name = "Number of items in cart")]
        public int CartQuantity { get; set; }

        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        public Transaction Transaction { get; set; }

        public ICollection<CartItem> CartItem { get; set; }

        // This model contains information about orders, their creation date, and how they are linked to the customer nad their cart.
    }
}
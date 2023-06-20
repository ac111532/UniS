using System.ComponentModel.DataAnnotations;
using UniS.Models;

public class Customer
{
    public int Customer_ID { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
    public string Customer_First_Name { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
    public string Customer_Last_Name { get; set; }

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Customer_Email { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    public string Customer_Phone_Number { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
    public string Customer_Address { get; set; }

    public ICollection<Order> Orders { get; set; }
    public ICollection<Cart> Carts { get; set; }
    public ICollection<Transaction> Transactions { get; set; }

    // Additional validation rules could be added here

}
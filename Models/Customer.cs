using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UniS.Models;

public class Customer : IdentityUser
{

    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
    public string CustomerFirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
    public string CustomerLastName { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
    public string CustomerAddress { get; set; }

    public ICollection<Order> Orders { get; set; }
    public ICollection<Transaction> Transactions { get; set; }

    // Additional validation rules could be added here
    //This Validation is missing naming.
}
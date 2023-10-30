using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UniS.Models;

public class Customer : IdentityUser
{

    [Required(ErrorMessage = "First name is required")]
    [Display(Name = "Customer Name")]
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

    // This model holds both the information about the customer, and the IdentityUser class that I created for the rolls to be added to. Without this, you wouldn't have role authorisation.
}
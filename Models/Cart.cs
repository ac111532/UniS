using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniS.Models;

public class Cart
{
    public int CartID { get; set; }

    public string? CustomerId { get; set; }
    public Customer Customer { get; set; }

    [Required(ErrorMessage = "Cart date is required")]
    [DataType(DataType.DateTime)]
    public DateTime CartDate { get; set; }

    public ICollection<CartItem> CartItems { get; set; }

    // Additional validation rules could be added here
}
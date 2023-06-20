using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniS.Models;

public class Cart
{
    public int Cart_ID { get; set; }

    public int? CustomerId { get; set; }
    public Customer Customer { get; set; }

    [Required(ErrorMessage = "Cart date is required")]
    [DataType(DataType.DateTime)]
    public DateTime Cart_Date { get; set; }

    public ICollection<CartItem> CartItems { get; set; }

    // Additional validation rules could be added here
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Order
{
    public int OrderID { get; set; }

    [Required(ErrorMessage = "Order date is required")]
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; }

    public int? CustomerID { get; set; }
    public Customer Customer { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }

    // Additional validation rules could be added here
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Order
{
    public int Order_ID { get; set; }

    [Required(ErrorMessage = "Order date is required")]
    [DataType(DataType.DateTime)]
    public DateTime Order_Date { get; set; }

    public int? Customer_ID { get; set; }
    public Customer Customer { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }

    // Additional validation rules could be added here
}
using System;
using System.ComponentModel.DataAnnotations;

public class Transaction
{
    public int Transaction_ID { get; set; }

    public int? CustomerId { get; set; }
    public Customer Customer { get; set; }

    [Required(ErrorMessage = "Transaction date is required")]
    [DataType(DataType.DateTime)]
    public DateTime Transaction_Date { get; set; }

    [Required(ErrorMessage = "Transaction price is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Transaction price must be greater than 0")]
    public int Transaction_Price { get; set; }

    // Additional validation rules could be added here
}
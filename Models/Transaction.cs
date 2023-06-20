using System;
using System.ComponentModel.DataAnnotations;

public class Transaction
{
    public int TransactionID { get; set; }

    public int? CustomerId { get; set; }
    public Customer Customer { get; set; }

    [Required(ErrorMessage = "Transaction date is required")]
    [DataType(DataType.DateTime)]
    public DateTime TransactionDate { get; set; }

    [Required(ErrorMessage = "Transaction price is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Transaction price must be greater than 0")]
    public int TransactionPrice { get; set; }

    // Additional validation rules could be added here
}
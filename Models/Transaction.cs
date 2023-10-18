using System;
using System.ComponentModel.DataAnnotations;
using UniS.Models;

public class Transaction
{
    [Key]
    public int TransactionID { get; set; }
    public decimal TransactionAmount { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime TransactionDate { get; set; }
    public int OrderID { get; set; }
    public Order Order { get; set; }

}
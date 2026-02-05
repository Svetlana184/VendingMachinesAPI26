using System;
using System.Collections.Generic;

namespace VendingMachinesApi26.Models;

public partial class Sale
{
    public int IdSale { get; set; }

    public string IdProduct { get; set; } = null!;

    public int Quantity { get; set; }

    public DateOnly Timestamp { get; set; }

    public decimal TotalPrice { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}

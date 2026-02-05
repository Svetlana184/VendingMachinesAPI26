using System;
using System.Collections.Generic;

namespace VendingMachinesApi26.Models;

public partial class Product
{
    public string IdProduct { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public int MinStock { get; set; }

    public string VendingMachineId { get; set; } = null!;

    public int QuantityAvaliable { get; set; }

    public double? SalesTrend { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual VendingMachine VendingMachine { get; set; } = null!;
}

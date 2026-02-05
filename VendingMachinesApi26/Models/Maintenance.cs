using System;
using System.Collections.Generic;

namespace VendingMachinesApi26.Models;

public partial class Maintenance
{
    public int IdMaintenance { get; set; }

    public string IdVendingMachine { get; set; } = null!;

    public string? IssuesFound { get; set; }

    public string IdUser { get; set; } = null!;

    public string? WorkDescription { get; set; }

    public DateTime? Date { get; set; }

    public virtual VendingMachine IdVendingMachineNavigation { get; set; } = null!;
}

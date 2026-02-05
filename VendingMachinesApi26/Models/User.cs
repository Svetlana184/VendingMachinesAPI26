using System;
using System.Collections.Generic;

namespace VendingMachinesApi26.Models;

public partial class User
{
    public string IdUser { get; set; } = null!;

    public string? Image { get; set; }

    public string FullName { get; set; } = null!;

    public bool IsManager { get; set; }

    public bool IsEngineer { get; set; }

    public string Phone { get; set; } = null!;

    public bool IsOperator { get; set; }

    public string Role { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public string? Login { get; set; }

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}

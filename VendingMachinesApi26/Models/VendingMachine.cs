using System;
using System.Collections.Generic;

namespace VendingMachinesApi26.Models;

public partial class VendingMachine
{
    public string IdVendingMachine { get; set; } = null!;

    public string? Name { get; set; }

    public string? Model { get; set; }

    public string? Payment { get; set; }

    public decimal? TotalIncome { get; set; }

    public int SerialNumber { get; set; }

    public int? InventNumber { get; set; }

    public string? Company { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? InstallDate { get; set; }

    public DateTime? LastMaintenanceDate { get; set; }

    public int? VerificationIntervalMonths { get; set; }

    public int? HoursResourse { get; set; }

    public DateTime? NextMaintenanceDate { get; set; }

    public int? MaintenanceHours { get; set; }

    public string Status { get; set; } = null!;

    public string? Country { get; set; }

    public DateTime? InventarizationDate { get; set; }

    public string? IdUser { get; set; }

    public string? RfidCash { get; set; }

    public string? Notes { get; set; }

    public string? Location { get; set; }

    public string? WorkMode { get; set; }

    public string? RfidLoading { get; set; }

    public string? KitOnlineId { get; set; }

    public string? CriticalThresholdTemplate { get; set; }

    public string? ServicePriority { get; set; }

    public string? Manager { get; set; }

    public string? NotificationTemplate { get; set; }

    public string? WorkingHours { get; set; }

    public string? Engineer { get; set; }

    public string? Place { get; set; }

    public string? Operator { get; set; }

    public string? Technician { get; set; }

    public string? RfidService { get; set; }

    public string? Coordinates { get; set; }

    public string? Timezone { get; set; }

    public DateTime? NextVerificationDate { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

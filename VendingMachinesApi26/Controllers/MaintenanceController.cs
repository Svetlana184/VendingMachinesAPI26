using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendingMachinesApi26.Models;

namespace VendingMachinesApi26.Controllers
{
    [ApiController]
    //[Authorize]
    public class MaintenanceController : ControllerBase
    {
        private VendingMachines26Context db;
        public MaintenanceController(VendingMachines26Context db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("api/maintenances")]
        public IQueryable GetMaintenances()
        {
            var query = from m in db.Maintenances
                        select new
                        {
                            m.IdMaintenance, 
                            m.IssuesFound,
                            m.WorkDescription,
                            m.Date,
                            m.IdUser,
                            m.IdVendingMachine
                        };
            return query;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendingMachinesApi26.Models;

namespace VendingMachinesApi26.Controllers
{
    [ApiController]
    [Authorize]
    public class VendingMachinesController : ControllerBase
    {
        private VendingMachines26Context db;
        public VendingMachinesController(VendingMachines26Context db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("api/machines")]
        public IQueryable GetVendingMachines()
        {
            var query = from vm in db.VendingMachines
                        select new
                        {
                            vm.IdVendingMachine,
                            vm.Name,
                            vm.Model,
                            vm.SerialNumber,
                            vm.InventNumber,
                            vm.Company,
                            vm.Location,
                            vm.Status,
                            vm.TotalIncome,
                            vm.LastMaintenanceDate,
                            vm.NextMaintenanceDate,
                            vm.InstallDate,
                            vm.CreatedDate
                        };
            return query;
        }
        [HttpGet]
        [Route("api/machines/{id}")]
        public IQueryable GetUser(string id)
        {
            var query = from u in db.Users
                        where u.IdUser == id
                        select new
                        {
                            u.IdUser,
                            u.FullName,
                            u.Email,
                            u.Phone,
                            u.Role,
                            u.IsManager,
                            u.IsEngineer,
                            u.IsOperator,
                            u.Image,
                            u.Login
                        };
            return query;
        }
    }
}

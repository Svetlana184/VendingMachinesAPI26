using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendingMachinesApi26.Models;

namespace VendingMachinesApi26.Controllers
{
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private VendingMachines26Context db;
        public UsersController(VendingMachines26Context db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("api/users")]
        public IQueryable GetUsers()
        {
            var query = from u in db.Users
                        select new
                        {
                            u.IdUser,
                            u.FullName,
                            u.Email,
                            u.Phone,
                            u.Role,
                            u.IsManager,
                            u.IsEngineer,
                            u.IsOperator
                        };
            return query;
        }
    }
}

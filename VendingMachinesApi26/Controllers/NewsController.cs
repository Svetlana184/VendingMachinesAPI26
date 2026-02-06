using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendingMachinesApi26.Models;

namespace VendingMachinesApi26.Controllers
{
    [ApiController]
    //[Authorize]
    public class NewsController : ControllerBase
    {

        private News[] news;

        public NewsController()
        {
            news = [
                new News{
                    Text = "new 1",
                    Date = DateOnly.FromDateTime(DateTime.Parse("2025-09-09"))
                },
                new News{
                    Text = "new 2",
                    Date = DateOnly.FromDateTime(DateTime.Parse("2025-09-19"))
                },
                new News{
                    Text = "new 3",
                    Date = DateOnly.FromDateTime(DateTime.Parse("2025-11-09"))
                },
                new News{
                    Text = "new 4",
                    Date = DateOnly.FromDateTime(DateTime.Parse("2025-12-09"))
                },
                new News{
                    Text = "new 5",
                    Date = DateOnly.FromDateTime(DateTime.Parse("2026-01-09"))
                },
                new News{
                    Text = "new 6",
                    Date = DateOnly.FromDateTime(DateTime.Parse("2026-01-09"))
                },
                new News{
                    Text = "new 7",
                    Date = DateOnly.FromDateTime(DateTime.Parse("2026-01-09"))
                }
            ];
        }

        [HttpGet]
        [Route("/api/news")]
        public IQueryable GetNews()
        {
            return news.AsQueryable();
        }
    }
}

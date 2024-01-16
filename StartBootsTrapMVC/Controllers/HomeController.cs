using Microsoft.AspNetCore.Mvc;
using StartBootsTrapMVC.Context;

namespace StartBootsTrapMVC.Controllers
{
	public class HomeController : Controller
	{
		StartDbContext _db { get; }

		public HomeController(StartDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			return View(_db.Details.ToList());
		}
	}
}

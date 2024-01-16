using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StartBootsTrapMVC.Areas.Admin.ViewModels;
using StartBootsTrapMVC.Context;
using StartBootsTrapMVC.Models;

namespace StartBootsTrapMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DetailController : Controller
    {
        StartDbContext _db { get; }

        public DetailController(StartDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Details.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDetailItemVM vm)
        {
            Detail detail = new Detail
            {
                Description = vm.Description,
                Name = vm.Name,
                ImageURL = vm.ImageURL
            };
            await _db.AddAsync(detail);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var item = await _db.Details.FindAsync(id);
            return View(new UpdateDetailItem
            {
                Description = item.Description,
                Name = item.Name,
                ImageURL = item.ImageURL
            });
        }

        [HttpPost]

        public async Task<IActionResult> Update(UpdateDetailItem vm, int id)
        {
            var item = await _db.Details.FindAsync(id);
            item.ImageURL = vm.ImageURL;
            item.Name = vm.Name;
            item.Description = vm.Description;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Details.FindAsync(id);
            _db.Details.Remove(item);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}

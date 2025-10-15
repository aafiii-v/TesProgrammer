using Microsoft.AspNetCore.Mvc;
using TesProgrammer.Interface;
using TesProgrammer.Models.DB;

namespace TesProgrammer.Controllers
{
    public class MataKuliahController : Controller
    {
        private readonly IMataKuliah _service;

        public MataKuliahController(IMataKuliah service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Matakuliah model)
        {
            if (ModelState.IsValid)
            {
                _service.Add(model);
                ViewBag.Message = "Data mata kuliah berhasil disimpan!";
            }

            var data = _service.GetAll();
            return View(data);
        }
    }
}
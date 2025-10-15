using Microsoft.AspNetCore.Mvc;
using TesProgrammer.Models.DB;
using TesProgrammer.Interface;

namespace TesProgrammer.Controllers
{
    public class DosenController : Controller
    {
        private readonly IDosen _dosenServices;

        public DosenController(IDosen dosenServices)
        {
            _dosenServices = dosenServices;
        }

        public IActionResult Index()
        {
            ViewBag.MataKuliahList = _dosenServices.GetAllMataKuliah();
            return View(new Dosen());
        }

        [HttpPost]
        public IActionResult Create(Dosen dosen, string SelectedMataKuliahIds)
        {
            if (ModelState.IsValid)
            {
                bool result = _dosenServices.Add(dosen);

                if (result)
                {
                    if (!string.IsNullOrEmpty(SelectedMataKuliahIds))
                    {
                        var mkIds = SelectedMataKuliahIds.Split(',').Select(int.Parse).ToList();

                        foreach (var mkId in mkIds)
                        {
                            _dosenServices.AddDosenMatakuliah(dosen.Id, mkId);
                        }
                    }

                    ViewBag.Message = "Data dosen dan mata kuliah berhasil disimpan!";
                    ViewBag.MataKuliahList = _dosenServices.GetAllMataKuliah();
                    return View("Index", new Dosen());
                }
            }

            ViewBag.Message = "Gagal menyimpan data dosen.";
            ViewBag.MataKuliahList = _dosenServices.GetAllMataKuliah();
            return View("Index", dosen);
        }
    }
}

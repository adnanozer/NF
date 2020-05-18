using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nefa.Data;
using Nefa.Models;

namespace Nefa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _modelContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _modelContext = new ModelContext();
            //to do Jquery çalışmıyor. sebebine bak
        }
        [HttpGet, ActionName("Index")]
        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel
            {
                dataModel = new DataModel(),
                dataModelList = _modelContext.GetAllData().ToList()
            };
            return View(indexViewModel);
        }

        [HttpPost, ActionName("Select")]
        public IActionResult Select(DataModel model)
        {
            var data = _modelContext.GetData(model);
            return View(data);
        }


        [HttpPost]
        public JsonResult CreateAjax(DataModel request) {

            int data;
            bool Success = new bool();
            if (request.id != null && request.id != 0)
            {
                data = _modelContext.Update(request);
            }
            else
            {
                data = _modelContext.Insert(request);
            }
            if (data != 1)
            {
                Success = false;
            }
            return Json(new {
                success = Success
            });
        }
        [HttpPost, ActionName("RefreshListAjax")]
        public ActionResult  RefreshListAjax()
        {
            IndexViewModel indexViewModel = new IndexViewModel
            {
                dataModelList = _modelContext.GetAllData().ToList()
            };
            //burada partial view şeklinde dönmem lazım ama core 3.1 de ViewEngines çalışmadı 
            //bu nedenle yetişmedi diyeyim. ajax çalışsaydı postback olmadan listey yenileyecektim.
            return PartialView("SelectList", indexViewModel.dataModelList);
        }

        [HttpPost, ActionName("Create")]

        public IActionResult Create(IndexViewModel model)
        {
            int data;
            if (model.dataModel.id != null && model.dataModel.id != 0)
            {
                data = _modelContext.Update(model.dataModel);
            }
            else
            {
                data = _modelContext.Insert(model.dataModel);
            }
            if (data != 1)
            {
                ModelState.AddModelError("Hata", "Kayıt işlemi yapılamadı");
            }
            return RedirectToAction("Index");
        }


        [HttpGet, ActionName("Update")]
        public IActionResult Update(DataModel model)
        {
            IndexViewModel indexViewModel = new IndexViewModel
            {
                dataModel = model,
                dataModelList = _modelContext.GetAllData().ToList()
            };
            return View("Index", indexViewModel);
        }

        [HttpGet, ActionName("Delete")]
        public IActionResult Delete(DataModel model)
        {
            var data = _modelContext.Delete(model);
            if (data != 1)
            {
                ModelState.AddModelError("Hata", "Silme işlemi yapılamadı");
            }
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TextumReader.ProblemDomain;
using TextumReader.DataLayer;
using TextumReader.DataLayer.Abstract;
using TextumReader.DataLayer.Concrete;
using Linguistics.Dictionary;
using TextumReader.WebUI.Models;
using TextumReader.Utilities;

namespace TextumReader.WebUI.Controllers
{
    public class MaterialController : Controller
    {
        IDictionary dictionary = new LingvoDictionary();

        private readonly IMaterialRepository _repository;

        public MaterialController(IMaterialRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(string category = "all")
        {
            var viewModel = new MaterialsListViewModel
            {
                Categories = _repository.Categories.Select(m => m.Name),
                CurrentCategory = category
            };

            viewModel.Materials = GetMaterialsWithCategory(category);              

            return View(viewModel);
        }

        public ViewResult MaterialList(string category = "all")
        {
            IEnumerable<Material> materials = GetMaterialsWithCategory(category);

            return View(materials);
        }

        public ViewResult Material(int id)
        {
            Material m = _repository.Materials.FirstOrDefault(p => p.MaterialId == id);
            m.ForeignText = TextProcessor.WrapWordsInTag(m.ForeignText, "w");
            return View(m);
        }

        public ViewResult Edit(int id)
        {
            Material material = _repository.Materials.FirstOrDefault(m => m.MaterialId == id);

            IEnumerable<Category> categories = _repository.Categories;
            ViewData["Categories"] = new SelectList(categories, "CategoryId", "Name");
            return View(material);
        }

        [HttpPost]
        public ActionResult Edit(Material material)
        {
            if (!ModelState.IsValid)
                return View(material);

            _repository.SaveMaterial(material);

            TempData["message"] = string.Format("{0}, has been saved", material.Title);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult TranslateWord(string word)
        {
            WordTranslation translation = dictionary.GetTranslation(word,
                TranslationDirection.EnRu);

            return Json(translation);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.DeleteMaterial(id);

            return View("MaterialList", _repository.Materials);
        }

        public ActionResult Create()
        {
            IEnumerable<Category> categories = _repository.Categories;
            ViewData["Categories"] = new SelectList(categories, "CategoryId", "Name");
            return View("Edit", new Material());
        }

        public ActionResult MaterialGrid()
        {
            return View(_repository.Materials);
        }

        #region Utility methods
        private IEnumerable<Material> GetMaterialsWithCategory(string category)
        {
            IEnumerable<Material> materials;
            if (category == "all" || string.IsNullOrEmpty(category))
                materials = _repository.Materials.ToList();
            else
                materials = _repository.Materials.Where(m => m.Category.Name == category);
            return materials;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.Models.Catalog;
using LibraryData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILibraryAsset _assets;

        public CatalogController(ILibraryAsset assets)
        {
            _assets = assets;
        }

        // GET: Catalog
        public async Task<ActionResult> Index()
        {
            var assets =await _assets.GetAll();
            var assetsModelTasks = assets.Select(async a => {

                var newAsset=new AssetIndexViewModel
                {
                    Id = a.Id,
                    ImgUrl = a.ImgUrl,
                    Title = a.Title,
                    AuthorOrDirector = await _assets.GetAuthorOrDirector(a.Id),
                    Type = await _assets.GetType(a.Id),
                    DeweyNumber = await _assets.GetDeweyIndex(a.Id),
                    NumberOfCopies = a.NumberOfCopies
                };
                return newAsset;
            });
            AssetIndexViewModel[] assetModel=await Task.WhenAll(assetsModelTasks);



            return View(assetModel.ToList());
        }

        // GET: Catalog/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var a= await _assets.GetById(id);

            var newAsset = new AssetDetailViewModel
            {
                Id = a.Id,
                ImgUrl = a.ImgUrl,
                Title = a.Title,
                AuthorOrDirector = await _assets.GetAuthorOrDirector(a.Id),
                Type = await _assets.GetType(a.Id),
                DeweyNumber = await _assets.GetDeweyIndex(a.Id),
                Year = a.Year,
                ISBN = await _assets.GetISBN(a.Id),
                Status= a.Status.Name,
                Price=a.Price,
                CurrentLocation= _assets.GetLibraryBranch(a.Id).Result.Name,
           
       
            };


            return View(newAsset);
        }

        // GET: Catalog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Catalog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Catalog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Catalog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Catalog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
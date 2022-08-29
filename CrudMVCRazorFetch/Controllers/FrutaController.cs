using CrudMVCRazorFetch.Models;
using CrudMVCRazorFetch.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVCRazorFetch.Controllers
{
    public class FrutaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<ListFrutaViewModel> lst = new List<ListFrutaViewModel>();
            using (CrudMVCRazorFetchEntities db =
                new CrudMVCRazorFetchEntities())
            {
                lst =
                   (from d in db.fruta
                    orderby d.id descending
                    select new ListFrutaViewModel
                    {
                        Id = d.id,
                        Name = d.name,
                        Cantidad = d.cantidad,
                        Origen = d.origen,
                        Precio = d.precio,
                    }).ToList();

            }
            return View(lst);
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(FrutaViewModel model)
        {
            try
            {

                using (CrudMVCRazorFetchEntities db = new CrudMVCRazorFetchEntities())
                {
                    var oFruta = new fruta();
                    oFruta.name = model.Name;
                    oFruta.cantidad = model.Cantidad;
                    oFruta.origen = model.Origen;
                    oFruta.precio = model.Precio;
                    db.fruta.Add(oFruta);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult Edit(int Id)
        {
            FrutaViewModel model = new FrutaViewModel();
            using (CrudMVCRazorFetchEntities db = new CrudMVCRazorFetchEntities())
            {
                var oFruta = db.fruta.Find(Id);
                model.Name = oFruta.name;
                model.Cantidad = oFruta.cantidad;
                model.Origen = oFruta.origen;
                model.Precio = oFruta.precio;
                model.Id = oFruta.id;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(FrutaViewModel model)
        {
            try
            {
                using (CrudMVCRazorFetchEntities db = new CrudMVCRazorFetchEntities())
                {
                    var oFruta = db.fruta.Find(model.Id);
                    oFruta.name = model.Name;
                    oFruta.cantidad = model.Cantidad;
                    oFruta.origen = model.Origen;
                    oFruta.precio = model.Precio;
                    db.Entry(oFruta).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                using (CrudMVCRazorFetchEntities db = new CrudMVCRazorFetchEntities())
                {
                    var oFruta = db.fruta.Find(Id);
                    db.fruta.Remove(oFruta);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}



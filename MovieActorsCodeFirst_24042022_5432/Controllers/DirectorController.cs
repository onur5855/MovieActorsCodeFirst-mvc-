using MovieActorsCodeFirst_24042022_5432.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieActorsCodeFirst_24042022_5432.Controllers
{
    public class DirectorController : BaseController
    {
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Director model)
        {
            Director director = new Director();
            director.FirstName = model.FirstName;
            director.LastName = model.LastName;
            director.BirthDate = model.BirthDate;
            db.Directors.Add(director);
            db.SaveChanges();
            return RedirectToAction("List");

        }

        public ActionResult List()
        {
            return View(db.Directors.Where(a=>a.IsActive).ToList());
        }

        public ActionResult Detail(int id)
        {
            return View(db.Directors.Find(id));
        }


        public ActionResult Update(int id)
        {
            return View(db.Directors.Find(id));
        }

        // dto kullanmadık ve validasyon yazmadık ama actor de bu şekilde olmayacak ikifarkı görelim istedik.
        [HttpPost]
        public ActionResult Update(Director director)
        {
            Director updated = db.Directors.Find(director.ID);

            updated.FirstName = director.FirstName;
            updated.LastName = director.LastName;
            updated.BirthDate = director.BirthDate;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            Director director = db.Directors.Find(id);
            director.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }


}
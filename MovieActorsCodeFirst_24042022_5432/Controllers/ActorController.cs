using MovieActorsCodeFirst_24042022_5432.Models;
using MovieActorsCodeFirst_24042022_5432.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieActorsCodeFirst_24042022_5432.Controllers
{
    public class ActorController : BaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateActorDTO dto)
        {
            if (ModelState.IsValid) // modelim geçerli kontrolleri sağlıyorsa
            {
                Actor actor = new Actor();
                actor.FirstName = dto.FirstName;
                actor.LastName = dto.LastName;
                actor.BirthDate = dto.BirthDate;
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else return View(dto);
        }

        public ActionResult List()
        {
            return View(db.Actors.Where(a=>a.IsActive).ToList());
        }

        public ActionResult Update(int id)
        {
            Actor actor = db.Actors.Find(id);

            UpdateActorDTO dto = new UpdateActorDTO();

            dto.FirstName = actor.FirstName;
            dto.LastName = actor.LastName;
            dto.BirthDate = actor.BirthDate.Value;
            dto.ID = actor.ID;

            return View(dto);
        }

        [HttpPost]
        public ActionResult Update(UpdateActorDTO model)
        {

            if (ModelState.IsValid)
            {
                Actor actor = db.Actors.Find(model.ID);
                actor.FirstName = model.FirstName;
                actor.LastName = model.LastName;
                actor.BirthDate = model.BirthDate;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else return View(model);
        }

        public ActionResult Delete(int id)
        {
            Actor actor = db.Actors.Find(id);

            return View(actor);
        }


        [HttpPost]
        public ActionResult Delete(Actor actor)
        {
            Actor actor1 = db.Actors.Find(actor.ID);
            actor1.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        // oyuncu detayyy
        public ActionResult Detail(int id)
        {
            
            return View(db.Actors.Find(id));
        }

    }
}
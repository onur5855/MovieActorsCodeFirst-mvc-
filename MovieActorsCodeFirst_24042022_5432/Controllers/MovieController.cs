using MovieActorsCodeFirst_24042022_5432.Models;
using MovieActorsCodeFirst_24042022_5432.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieActorsCodeFirst_24042022_5432.Controllers
{
    public class MovieController : BaseController
    {
             
        public ActionResult Create()
        {
            // yönetmenlerimizi gönderelim.
            List<SelectListItem> yonetmenler = new List<SelectListItem>();

            foreach (Director item in db.Directors.Where(a=>a.IsActive).ToList())
            {
                yonetmenler.Add( new SelectListItem { Text=item.ToString(), Value=item.ID.ToString() });
            }


            // oyuncularımızı gönderelim.

            List<ActorSelectDTO> oyuncular = db.Actors.Where(a => a.IsActive).Select(a => new ActorSelectDTO { ID = a.ID, FirstName = a.FirstName, LastName = a.LastName, IsSelected = false }).ToList();

            return View(Tuple.Create<Movie, List<ActorSelectDTO>, List<SelectListItem>>(new Movie(),oyuncular,yonetmenler));

        }


        [HttpPost]
        public ActionResult Create([Bind(Prefix ="Item1")] Movie model1,[Bind(Prefix ="Item2")] List<ActorSelectDTO> model2) 
            // bind => kaynak göstermek gibi düşünebilirz.Bu şekilde model1 in kaynağının sayfadan gelen İtem1 yani Movie olduğunu söylemiş olduk ki tipleri de aynı
            // olduğu için hata verilmedi.
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie();

                movie.MovieName = model1.MovieName;
                movie.PublishDate = model1.PublishDate;
                movie.DirectorID = model1.DirectorID;
                movie.Director = db.Directors.Find(movie.DirectorID);

                MovieActors movieActors;
                foreach (ActorSelectDTO item in model2.Where(a => a.IsSelected))
                {
                    movieActors = new MovieActors();
                    movieActors.ActorID = item.ID;
                    movieActors.Actor = db.Actors.Find(item.ID);
                    movieActors.Movie = movie;
                    db.MovieActors.Add(movieActors);    // ara tablo elemanını kendi tablosuna ekledim
                    movie.MovieActors.Add(movieActors); // ara tabloya kaydolan elemanı moviye ekledim.

                }
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("List", "Movie");
            }
            else return View();


        }

        [HttpGet]
        public ActionResult List()
        {
            return View(db.Movies.Where(a=>a.IsActive).ToList());
        }

        public ActionResult Detail(int id)
        {
            return View(db.Movies.Find(id));

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Movie movie= db.Movies.Find(id);
                       
            //yonetmen seçimi için
            List<SelectListItem> yonetmenler=new List<SelectListItem>();
            foreach (var item in db.Directors.Where(a=>a.IsActive).ToList())
            {
                yonetmenler.Add(new SelectListItem { Text=item.ToString() , Value=item.ID.ToString() });
            }
            //secili olan oyuncular
            List<ActorSelectDTO> secilioyuncular=new List<ActorSelectDTO>();
            foreach (MovieActors item in movie.MovieActors)
            {
                secilioyuncular.Add(new ActorSelectDTO { ID=item.ActorID,FirstName=item.Actor.FirstName,LastName=item.Actor.LastName,IsSelected=true });
            }
            //tum oyuncular için
            List<ActorSelectDTO> tumoyuncular=db.Actors.Where(a=>a.IsActive).Select(a=>new ActorSelectDTO 
            { ID=a.ID,FirstName=a.FirstName,LastName=a.LastName,IsSelected=false }).ToList();
            //tum oyuncuları gönderirken zaten secili olanların ısselected özelliklerini işaretleyip tek liste göndermek için iç içe for dönüp tek bir liste gönderebiliriz
            for (int i = 0; i < tumoyuncular.Count; i++)
            {
                for (int a = 0; a < secilioyuncular.Count; a++)
                {
                    if (tumoyuncular[i].ID==secilioyuncular[a].ID)
                    {
                        tumoyuncular[i].IsSelected = true;
                    }
                }


            }
            return View(Tuple.Create<Movie,List<ActorSelectDTO>,List<SelectListItem>>(movie,tumoyuncular,yonetmenler));
        }
        [HttpPost]
        public ActionResult Update( [Bind(Prefix = "Item1")] Movie model1, [Bind(Prefix = "Item2")] List<ActorSelectDTO> model2 )
        {
            if (ModelState.IsValid)
            {
                Movie update = db.Movies.Find(model1.ID);
                update.MovieName = model1.MovieName;
                update.PublishDate = model1.PublishDate;
                update.DirectorID = model1.DirectorID;
                update.Director=db.Directors.Find(model1.DirectorID);

                db.MovieActors.RemoveRange(update.MovieActors);

                MovieActors movieActors;
                foreach (ActorSelectDTO item in model2.Where(a => a.IsSelected))
                {
                    movieActors = new MovieActors();
                    movieActors.ActorID = item.ID;
                    movieActors.Actor = db.Actors.Find(item.ID);
                    movieActors.Movie = update;
                    db.MovieActors.Add(movieActors);    // ara tablo elemanını kendi tablosuna ekledim
                    update.MovieActors.Add(movieActors); // ara tabloya kaydolan elemanı moviye ekledim.

                }
                db.SaveChanges();
                return RedirectToAction("list");
            }
            else return View();
        }

        // movie silme 
        public ActionResult Delete(int id)
        {
            db.Movies.Find(id).IsActive = false;
            db.SaveChanges();
            return RedirectToAction("List");
        }





    }
}
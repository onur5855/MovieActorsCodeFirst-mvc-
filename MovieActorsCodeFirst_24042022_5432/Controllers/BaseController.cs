using MovieActorsCodeFirst_24042022_5432.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieActorsCodeFirst_24042022_5432.Controllers
{
    public class BaseController : Controller
    {
        public ProjectContext db;
        public BaseController()
        {
            db = new ProjectContext();
        }
    }
}
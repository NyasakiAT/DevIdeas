using DevIdeas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIdeas.Controllers
{

    public class ApiController : Controller
    {
        DbAccess db;
        public ApiController()
        {
            db = new DbAccess();
        }

        [HttpPost]
        public IActionResult Index(FormModel form)
        {
            db.CreateProjectEntry(form.Title, form.Description, form.Tags.Split(",").ToList());
            return Redirect("/");
        }
    }
}

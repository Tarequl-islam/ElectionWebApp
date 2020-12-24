using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectionWebApp.Manager;
using ElectionWebApp.Models;

namespace ElectionWebApp.Controllers
{
    public class CastVoteController : Controller
    {
        CastVoteManager castVoteManager = new CastVoteManager();
        //
        // GET: /CastVote/
        [HttpGet]
        public ActionResult Cast()
        {
            ViewBag.Candidates = castVoteManager.GetAllCandidatesForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Cast(CastVote castVote)
        {
            ViewBag.Candidates = castVoteManager.GetAllCandidatesForDropdown();

            if (ModelState.IsValid)
            {
                string messege = castVoteManager.Save(castVote);
                ViewBag.Message = messege;
                if (messege == "Cast Successful")
                {
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.Message = "ModelState is Invalid";
            }
            return View();
        }
	}
}
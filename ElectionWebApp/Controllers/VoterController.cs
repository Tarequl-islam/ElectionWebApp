using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectionWebApp.Manager;
using ElectionWebApp.Models;

namespace ElectionWebApp.Controllers
{
    public class VoterController : Controller
    {
        VoterManager voterManager = new VoterManager();
        // GET: /Voter/
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Voter voter)
        {
            if (ModelState.IsValid)
            {
                string messege = voterManager.Save(voter);
                ViewBag.Message = messege;
                if (messege == "Save Successful")
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
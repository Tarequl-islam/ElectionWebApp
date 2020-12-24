using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectionWebApp.Manager;
using ElectionWebApp.Models;

namespace ElectionWebApp.Controllers
{
    public class CandidateController : Controller
    {
        CandidateManager candidateManager =new CandidateManager();
        //
        // GET: /Candidate/
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                string messege = candidateManager.Save(candidate);
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
        public ActionResult Result()
        {
            List<Candidate> candidateList = candidateManager.GetResultCandidates();
            return View(candidateList);
        }
	}
}
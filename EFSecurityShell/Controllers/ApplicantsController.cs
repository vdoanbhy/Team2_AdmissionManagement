using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team2_AdmissionManagement.Data;
using Team2_AdmissionManagement.Models;
using Team2_AdmissionManagement.ViewModels;


namespace Team2_AdmissionManagement.Controllers
{
    public class ApplicantsController : Controller
    {
        private Team2_AdmissionManagementContext db = new Team2_AdmissionManagementContext();

        // GET: Applicants
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Index(string search)
        {

            var applicants = db.Applicants.Include(p => p.Reviews);
            if (!String.IsNullOrEmpty(search))
            {
                applicants = applicants.Where(a=> a.SSN.Contains(search) || a.LastName.Contains(search));
            }
            //var applicants = db.Applicants.Include(a => a.Interest);
            return View(applicants.ToList());
        }

        // GET: Applicants/Details/5
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create
        public ActionResult Create()
        {
            ViewBag.InterestID = new SelectList(db.Interests, "ID", "Major");
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SSN,LastName,MiddleName,FirstName,Gender,DoB,Street,City,State,Zip,HomePhone,CellPhone,InstitutionName,InstitutionCity,GraduationDate,GPA,MathSAT,VerbalSAT,InterestID,SubmissionDate")] Applicant applicant)
        {
            ViewBag.InterestID = new SelectList(db.Interests, "ID", "Major", applicant.InterestID);

            if (ModelState.IsValid)
            {
                Applicant matchingApplicant = db.Applicants.Where(cm => string.Compare(cm.SSN, applicant.SSN, true) == 0).FirstOrDefault();

                if (applicant == null)
                {
                    return HttpNotFound();
                }

                if (matchingApplicant != null)
                {
                    ModelState.AddModelError("SSN", "This SSN was already entered.");
                    return View(applicant);
                }

                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(applicant);
        }

        // GET: Applicants/Edit/5
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            ViewBag.InterestID = new SelectList(db.Interests, "ID", "Major", applicant.InterestID);
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SSN,LastName,MiddleName,FirstName,Gender,DoB,Street,City,State,Zip,HomePhone,CellPhone,InstitutionName,InstitutionCity,GraduationDate,GPA,MathSAT,VerbalSAT,InterestID,SubmissionDate")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InterestID = new SelectList(db.Interests, "ID", "Major", applicant.InterestID);
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

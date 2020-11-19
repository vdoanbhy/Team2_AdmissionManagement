using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Team2_AdmissionManagement.Models;

namespace Team2_AdmissionManagement.ViewModels
{
    public class ApplicantMangementViewModel
    {
        public IQueryable<Applicant> Applicants { get; set; }
        [Display(Name="Full Name")]
        public string FullName { get; set; }
        [Display(Name ="Combine SAT Score")]
        public int CombineSATScore { get; set; }
        [Display(Name = "Enrollment Term")]
        public string EnrollmentTerm { get; set; }

    }
}
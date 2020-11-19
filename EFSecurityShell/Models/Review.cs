using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team2_AdmissionManagement.Models
{
    public enum Decisions
    {
        Admit, Reject, Waitlist
    }
    public class Review
    {
        public int ID { get; set; }
        public int ApplicantID { get; set; }
        public virtual Applicant Applicant { get; set; }
        public Decisions? Decision { get; set; }
    }
}
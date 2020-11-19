using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team2_AdmissionManagement.Models
{
    public enum Terms
    {
        Fall, Spring, Summer
    }
    public class Interest
    {
        public int ID { get; set; }
        [Display(Name="Major of Interest")]
        public string Major { get; set; }
        public Terms Terms { get; set; }
        public string Year { get; set; }
        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
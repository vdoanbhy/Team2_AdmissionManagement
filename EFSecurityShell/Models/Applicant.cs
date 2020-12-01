using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team2_AdmissionManagement.Models
{
    public enum State
    {
        AL, AK, AZ, AR, CA, CO, CT, DC, DE, FL, GA,
        HI, ID, IL, IN, IA, KS, KY, LA, ME, MD,
        MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ,
        NM, NY, NC, ND, OH, OK, OR, PA, RI, SC,
        SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
    }
    public enum Gender
    {
        Male, Female, Other
    }
    public class Applicant
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Not a valid SSN.")]
        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        [Required]
        public string MiddleName { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        public Gender? Gender { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DoB { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public State? State { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public int Zip { get; set; }
        [Required(ErrorMessage = "You must provide a phone number.")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number.")]
        public string HomePhone { get; set; }
        [Required(ErrorMessage = "You must provide a phone number.")]
        [Display(Name = "Cell Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number.")]
        public string CellPhone { get; set; }
        [Display(Name = "High School's Name")]
        public string InstitutionName { get; set; }
        [Display(Name = "High School's City")]
        public string InstitutionCity { get; set; }
        [Required]
        [Display(Name = "Graduation Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime GraduationDate { get; set; }
        [Required]
        [Range(3.0, 4.0, ErrorMessage = "You do not meet the minimum qualifications.")]
        public decimal GPA { get; set; }
        [Required]
        [Range(200, 800, ErrorMessage = "You do not meet the minimum qualifications.")]
        [Display(Name = "Math SAT Score")]
        public int MathSAT { get; set; }
        [Required]
        [Range(200, 800, ErrorMessage = "You do not meet the minimum qualifications.")]
        [Display(Name = "Verbal SAT Score")]
        public int VerbalSAT { get; set; }
        [Display(Name = "Major of Interest")]
        public int? InterestID { get; set; }
        [Display(Name = "Major of Interest")]
        public virtual Interest Interest { get; set; }
        [Required]
        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
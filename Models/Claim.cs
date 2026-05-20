using System;
using System.ComponentModel.DataAnnotations;

namespace CLAIM.SYSTEM.POE.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; } // Renamed from 'Id' to match Controller

        [Required]
        public int LecturerId { get; set; }

        [Required]
        [Display(Name = "Hours Worked")]
        [Range(1, 200, ErrorMessage = "Hours worked must be between 1 and 200.")]
        public double HoursWorked { get; set; }

        [Required]
        [Display(Name = "Hourly Rate")]
        [Range(50, 2000, ErrorMessage = "Hourly rate must be between 50 and 2000.")]
        public double HourlyRate { get; set; }

        // CHANGED: Made this writable { get; set; } so the Controller can save the final calculation
        [Display(Name = "Total Amount")]
        public double TotalAmount { get; set; }

        [Display(Name = "Additional Notes")]
        public string Notes { get; set; }

        // CHANGED: Renamed from 'DocumentName' to 'FileName' to match Controller logic
        public string FileName { get; set; }

        // Status: Pending, Approved, Rejected
        public string Status { get; set; }

        public DateTime SubmissionDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Calls
    {
        [Required]
        [Display(Name = "ID")]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Key]
        public string CallID { get; set; }
        [Required]

        [Display(Name = "Student ID")]
        public string StudentID { get; set; }

        public string TechID { get; set; }

        [Display(Name = "Subject Line")]
        [StringLength(100, MinimumLength = 2)]

        [Required]
        public string SubjectLine { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, MinimumLength = 2)]
        public string Description { get; set; }
        [Display(Name = "Priority")]
        public priority Priority { get; set; }
        [Display(Name = "Status")]
        public status Status { get; set; }
        [Display(Name = "Comment")]
        [StringLength(500, MinimumLength = 2)]
        public string Comment { get; set; }
        [Display(Name = "Log Date")]
        public DateTime LogDate { get; set; }

        [Display(Name = "Close Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CloseDate { get; set; }
        public enum priority
        {
            Low,
            Medium,
            High
        }
        public enum status
        {
            Open,
            Logged,
            Assigned,
            Closed
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Core.Models
{
    public class Enrollment
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        public DateTime EnrollmentDate {  get; set; }
        public Status Status { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string CourseId { get; set; }
        public Course Course { get; set; }


    }
    public enum Status
    {
        Active,
        Completed
    }
}

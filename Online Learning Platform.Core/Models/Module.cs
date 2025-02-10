using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Online_Learning_Platform.Core.Models
{
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
        [JsonIgnore]
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();



    }
}

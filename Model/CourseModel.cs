using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstDapper.Model
{
    [Table("Course")]
    public class CourseModel
    {
        [Key]
        [Column("CourseId")]
        public int Id { get; set; }
        [Column("CourseName")]
        public string CourseName { get; set; }
        [Column("Description")]
        public string Description { get; set; }
    }
}
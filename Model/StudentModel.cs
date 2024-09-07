using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstDapper.Model
{
    [Table("Student")]
    public class StudentModel
    {
        [Key]
        [Column("StudentId")]
        public int Id { get; set; }

        [Column("Id")]
        public string FirstName { get; set; }

        [Column("Id")]
        public string LastName { get; set; }
    }
}

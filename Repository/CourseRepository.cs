using MyFirstDapper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstDapper.Repository
{
    public class CourseRepository : GenericRepository<CourseModel>
    {
    }
}
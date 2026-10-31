using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Department:ModelBase
    {
       

        [Required (ErrorMessage = "Code IS Required ")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name IS Required ")]
        public string Name { get; set; }
        [Display(Name= "Date Of Creation")]
        public DateTime DateOfCreation { get; set; }

        //Navigatio Property =[many]
        //[InverseProperty(nameof(Employee.Department))]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}

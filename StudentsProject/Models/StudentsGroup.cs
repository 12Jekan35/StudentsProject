using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Models
{
    public class StudentsGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearCreation { get; set; }
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }

        public override string ToString()
        {
            return $"{DateTime.Now.Year - YearCreation}-{YearCreation-2000} {Name}";
        }
    }
}

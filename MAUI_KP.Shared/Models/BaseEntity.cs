using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_KP.Shared.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
    }

    public class Employer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public string Post { get; set; }
        public int Age { get; set; }
    }

}

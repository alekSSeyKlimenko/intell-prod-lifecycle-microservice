using System;
using System.Collections.Generic;

namespace IntellProdLifeCycleMS.Domain.Models
{
    public class Book:Publication
    {
        public Book()
        {
        }

        public string Organization { get; set; }
        public int Level { get; set; }
        public List<EducationalProgram> EducationalPrograms { get; set; }
    }
}

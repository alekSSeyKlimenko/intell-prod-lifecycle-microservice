using System;
namespace IntellProdLifeCycleMS.Domain.Models
{
    public class EducationalProgram
    {
        public EducationalProgram()
        {
        }

        public int Id { get; set; }
        public string EdProgramName { get; set; }

        public int? BookId { get; set; }
        public Book Book { get; set; }
    }
}

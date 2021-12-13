using System;
namespace IntellProdLifeCycleMS.Domain.Models
{
    public class Indexation
    {
        public Indexation()
        {

        }

        public int Id { get; set; }
        public int Type { get; set; }
        public int Link { get; set; }

        public int? IntelliegentWorkId { get; set; }
        public IntelliegentWork IntelliegentWork { get; set; }
    }
}

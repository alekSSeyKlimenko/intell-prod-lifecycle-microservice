using System;
namespace IntellProdLifeCycleMS.Domain.Models
{
    public class Publication: IntelliegentWork
    {
        public Publication()
        {
        }

        public string Publisher { get; set; }
        public string Edition { get; set; }
        public string UDK { get; set; }
        public int PageCount { get; set; }
    }
}

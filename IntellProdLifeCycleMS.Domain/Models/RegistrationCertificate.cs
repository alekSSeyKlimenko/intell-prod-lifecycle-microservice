using System;
namespace IntellProdLifeCycleMS.Domain.Models
{
    public class RegistrationCertificate:IntelliegentWork
    {
        public RegistrationCertificate()
        {
        }

        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string RightHolder { get; set; }
        public int Number { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime RequestDate { get; set; }
    }
}

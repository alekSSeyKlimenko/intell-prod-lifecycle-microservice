using System;
using System.Collections.Generic;

namespace IntellProdLifeCycleMS.Domain.Models
{
    public class IntelliegentWork
    {
        public IntelliegentWork()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Type { get; set; }
        public int DOI { get; set; }
        public string Year { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string GRINTI { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public List<Author> Authors { get; set; }
        public List<Indexation> Indexations { get; set; }
        public List<KeyWord> KeyWords { get; set; }
    }
}

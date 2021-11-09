using System;
namespace IntellProdLifeCycleMS.Domain.Models
{
    public class Article: Publication
    {
        public Article()
        {
        }

        public string CollectionTitle { get; set; }

        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int MagazineNumber { get; set; }
        public int Part { get; set; }
        public string Conference { get; set; }

        
    }
}

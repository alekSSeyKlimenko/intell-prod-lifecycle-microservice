using System;
namespace IntellProdLifeCycleMS.Domain.Models
{
    public class Author
    {
        public Author()
        {
        }

        public int Id { get; set; }
        public int UserID { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int ShortFirstName { get; set; }
        public int ShortPatronamicName { get; set; }
        public int PatronamicName { get; set; }
        public int NumberInList { get; set; }

        public IntelliegentWork IntelliegentWork { get; set; }
    }
}
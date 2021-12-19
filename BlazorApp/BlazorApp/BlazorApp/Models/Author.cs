using System;
namespace BlazorApp.Models
{
    public class Author
    {
        public Author()
        {
        }

        public int Id { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortFirstName { get; set; }
        public string ShortPatronamicName { get; set; }
        public string PatronamicName { get; set; }
        public int NumberInList { get; set; }

        public int? IntelliegentWorkId { get; set; }
        public IntelliegentWork IntelliegentWork { get; set; }
    }
}
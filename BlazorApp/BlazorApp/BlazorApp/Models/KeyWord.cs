using System;
namespace BlazorApp.Models
{
    public class KeyWord
    {
        public KeyWord()
        {

        }

        public int Id { get; set; }
        public string Word { get; set; }

        public int? IntelliegentWorkId { get; set; }
        public IntelliegentWork IntelliegentWork { get; set; }
    }
}


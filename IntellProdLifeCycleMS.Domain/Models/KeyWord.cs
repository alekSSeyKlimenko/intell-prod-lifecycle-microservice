using System;
namespace IntellProdLifeCycleMS.Domain.Models
{
    public class KeyWord
    {
        public KeyWord()
        {

        }

        public int Id { get; set; }
        public string Word { get; set; }

        public IntelliegentWork IntelliegentWork { get; set; }
    }
}

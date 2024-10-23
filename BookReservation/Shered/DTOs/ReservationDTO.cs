using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.DTOs
{
    public class ReservationDTO
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Days { get; set; }
        public bool QuickPickUp {  get; set; }
        public decimal TotalCost { get; set; }
        public BookType SelectedType { get; set; }
    }
}

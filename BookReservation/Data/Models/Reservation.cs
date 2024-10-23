using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Days { get; set; }
        public bool QuickPickUp {  get; set; }
        public decimal TotalCost { get; set; }
    }
}

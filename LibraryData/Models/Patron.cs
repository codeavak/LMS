using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class Patron
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }

        public virtual LibraryCard LibraryCard { get; set; }
        public virtual LibraryBranch LibraryBranch { get; set; }
    }
}

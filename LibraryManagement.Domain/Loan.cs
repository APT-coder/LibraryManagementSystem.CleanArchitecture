using LibraryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain
{
    public class Loan : BaseEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

}

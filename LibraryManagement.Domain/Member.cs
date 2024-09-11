using LibraryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }

}

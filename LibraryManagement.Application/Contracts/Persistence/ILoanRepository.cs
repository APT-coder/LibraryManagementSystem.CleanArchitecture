using LibraryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Persistence
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        Task<IEnumerable<Loan>> GetLoansByMemberIdAsync(int memberId);
        Task<IEnumerable<Loan>> GetActiveLoansAsync();
    }

}

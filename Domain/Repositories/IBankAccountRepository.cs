using System.Collections.Generic;
using System.Threading.Tasks;
using XcdifyConnect.Domain.Entities;

namespace XcdifyConnect.Domain.Repositories
{
    public interface IAxisBankTransactionRepository
    {
        Task<IEnumerable<AxisBankTransaction>> GetAllAsync(int pageNumber,int pageSize);
        Task<AxisBankTransaction> GetByIdAsync(int id);
        Task AddAsync(AxisBankTransaction transaction);
        Task UpdateAsync(AxisBankTransaction transaction);
        Task DeleteAsync(int id);
    }
}

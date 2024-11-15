using System.Collections.Generic;
using System.Threading.Tasks;
using XcdifyConnect.Application.DTOs;


namespace XcdifyConnect.Application.Interfaces
{
    public interface IAxisBankTransactionService
    {
        Task<IEnumerable<AxisBankTransactionDto>> GetAllTransactionsAsync(int pageNumber,int pageSize);
        Task<AxisBankTransactionDto> GetTransactionByIdAsync(int id);
        Task AddTransactionAsync(AxisBankTransactionDto transactionDto);
        Task UpdateTransactionAsync(AxisBankTransactionDto transactionDto);
        Task DeleteTransactionAsync(int id);
    }
}

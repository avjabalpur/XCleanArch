using Microsoft.Graph.Models;
using Microsoft.Graph.Models.CallRecords;

namespace XcdifyConnect.Domain.Services
{
	public interface IMicrosoftGraphService
	{
		Task<List<CallRecord>> GetCallRecordsAsync(DateTime? startDate = null, DateTime? endDate = null);
		Task<CallRecord> GetCallRecordDetailAsync(string id);
		Task<List<CallRecord>> GetUserCallRecordsAsync(string userId, DateTime? startDate = null, DateTime? endDate = null);
		Task<List<User>> GetUsersAsync();
	}
}

using XcdifyConnect.Application.DTOs;

namespace XcdifyConnect.Application.Interfaces
{
	public interface ICallRecordService
	{
		Task<List<CallRecordDto>> GetCallRecordsAsync(DateTime? startDate = null, DateTime? endDate = null);
		Task<CallDetailsDto> GetCallRecorDetailsAsync(string id);
		Task<List<CallRecordDto>> GetUserCallRecordsAsync(string userId, DateTime? startDate = null, DateTime? endDate = null);
	}
}

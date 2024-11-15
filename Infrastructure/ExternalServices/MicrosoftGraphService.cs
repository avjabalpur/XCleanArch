using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.CallRecords;
using XcdifyConnect.Domain.Services;

namespace XcdifyConnect.Infrastructure.ExternalServices
{
	public class MicrosoftGraphService : IMicrosoftGraphService
	{
		private readonly GraphServiceClient _graphClient;

		public MicrosoftGraphService(GraphServiceClient graphClient)
		{
			_graphClient = graphClient;
		}

		public async Task<List<CallRecord>> GetCallRecordsAsync(DateTime? startDate = null, DateTime? endDate = null)
		{
			var callRecords = await _graphClient.Communications.CallRecords.GetAsync();
			if (callRecords != null)
			{
				var results = callRecords.Value
					.Where(c =>
						(!startDate.HasValue || c.StartDateTime >= startDate.Value) &&
						(!endDate.HasValue || c.StartDateTime <= endDate.Value))
					.ToList();
				return results.ToList();
			}
			return null;
		}

		public async Task<CallRecord> GetCallRecordDetailAsync(string id)
		{
			var callRecord = await _graphClient.Communications.CallRecords[id].GetAsync();
			if (callRecord != null)
			{
				return callRecord;
			}
			return null;
		}

		public async Task<List<User>> GetUsersAsync()
		{
			var users = await _graphClient.Users.GetAsync();
			if (users != null)
			{
				return users.Value.ToList();
			}
			return null;
		}

		public async Task<List<CallRecord>> GetUserCallRecordsAsync(string userId, DateTime? startDate = null, DateTime? endDate = null)
		{
			var callRecordsPage = await _graphClient.Communications.CallRecords.GetAsync();

			if (callRecordsPage != null)
			{
				var results = callRecordsPage.Value
					.Where(c =>
						(c.Participants.Any(p => p.User?.Id == userId) || c.Organizer?.User?.Id == userId) &&
						(!startDate.HasValue || c.StartDateTime >= startDate.Value) &&
						(!endDate.HasValue || c.StartDateTime <= endDate.Value))
					.ToList();
				return results;
			}

			return null;
		}

	}
}

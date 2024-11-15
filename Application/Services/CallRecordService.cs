using Microsoft.IdentityModel.Tokens;
using XcdifyConnect.Application.DTOs;
using XcdifyConnect.Application.Interfaces;
using XcdifyConnect.Common;
using XcdifyConnect.Domain.Services;

namespace XcdifyConnect.Application.Services
{
	public class CallRecordService : ICallRecordService
	{
		private readonly IMicrosoftGraphService _microsoftGraphService;
		public CallRecordService(IMicrosoftGraphService microsoftGraphService)
		{
			_microsoftGraphService = microsoftGraphService;
		}

		public async Task<List<CallRecordDto>> GetCallRecordsAsync(DateTime? startDate = null, DateTime? endDate = null)
		{
			var callRecords = await _microsoftGraphService.GetCallRecordsAsync(startDate, endDate);
			if (callRecords != null) {
				var results = callRecords.
								Select(c => ToCallRecords(c));
				return results.ToList();
			}
			return null;
		}

		public async Task<CallDetailsDto> GetCallRecorDetailsAsync(string id)
		{
			var callRecord = await _microsoftGraphService.GetCallRecordDetailAsync(id);
			if (callRecord != null)
			{
				return new CallDetailsDto
				{
					Id = callRecord.Id,
					EndDateTime = callRecord.EndDateTime,
					JoinWebUrl = callRecord.JoinWebUrl,
					LastModifiedDateTime = callRecord.LastModifiedDateTime,
					StartDateTime = callRecord.StartDateTime,
					Type = callRecord.Type.ToString(),
					OrganizerName = callRecord.Organizer?.User?.DisplayName,
					Duration = $"{DateTimeUtils.CalculateDuration(callRecord.StartDateTime, callRecord.EndDateTime, TimeUnit.Minutes)} Minutes",
					Organizer = BindOrganizer(callRecord.Organizer),
					Participants = callRecord.Participants?.Select(p => BindParticipant(p)).ToList(),
				};
			}
			return null;
		}
		

		public async Task<List<CallRecordDto>> GetUserCallRecordsAsync(string userId, DateTime? startDate = null, DateTime? endDate = null)
		{
			var callRecords = await _microsoftGraphService.GetUserCallRecordsAsync(userId, startDate, endDate);

			if (callRecords != null)
			{
				var results = callRecords
					.Select(c => ToCallRecords(c));
				return results.ToList();
			}

			return null;
		}

		private static CallRecordDto ToCallRecords(Microsoft.Graph.Models.CallRecords.CallRecord c)
		{
			return new CallRecordDto
			{
				Id = c.Id,
				EndDateTime = c.EndDateTime,
				JoinWebUrl = c.JoinWebUrl,
				LastModifiedDateTime = c.LastModifiedDateTime,
				StartDateTime = c.StartDateTime,
				Type = c.Type.ToString(),
				OrganizerName = c.Organizer.User.DisplayName,
				Duration = $"{DateTimeUtils.CalculateDuration(c.StartDateTime, c.EndDateTime, TimeUnit.Minutes)} Minutes"
			};
		}

		private IdentitySet BindOrganizer(Microsoft.Graph.Models.IdentitySet organizer)
		{
			return new IdentitySet
			{
				User = organizer.User == null ? null : new Identity
				{
					Id = organizer.User.Id,
					DisplayName = organizer.User.DisplayName
				},
				Application = organizer.Application == null ? null : new Identity
				{
					Id = organizer.Application.Id,
					DisplayName = organizer.Application.DisplayName
				},
				Device = organizer.Device == null ? null : new Identity
				{
					Id = organizer.Device.Id,
					DisplayName = organizer.Device.DisplayName
				}
			};
		}

		private IdentitySet BindParticipant(Microsoft.Graph.Models.IdentitySet participant)
		{
			return new IdentitySet
			{
				User = participant.User == null ? null : new Identity
				{
					Id = participant.User.Id,
					DisplayName = participant.User.DisplayName
				},
				Application = participant.Application == null ? null : new Identity
				{
					Id = participant.Application.Id,
					DisplayName = participant.Application.DisplayName
				},
				Device = participant.Device == null ? null : new Identity
				{
					Id = participant.Device.Id,
					DisplayName = participant.Device.DisplayName
				}
			};
		}
	}
}

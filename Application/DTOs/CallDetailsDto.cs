
namespace XcdifyConnect.Application.DTOs
{
	public class CallDetailsDto : CallRecordDto
	{
		public IdentitySet? Organizer { get; set; }
		public List<IdentitySet>? Participants { get; set; }
		public long? Version { get; set; }
		public string? Modality { get; set; }
	}

	public class IdentitySet
	{
		public Identity? User { get; set; }
		public Identity? Application { get; set; }
		public Identity? Device { get; set; }
	}

	public class Identity
	{
		public string? Id { get; set; }
		public string? DisplayName { get; set; }
	}
}

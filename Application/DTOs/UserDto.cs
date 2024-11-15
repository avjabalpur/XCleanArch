
namespace XcdifyConnect.Application.DTOs
{
	public class UserDto
	{
		public string? Id { get; set; }
		public DateTimeOffset? Birthday { get; set; }

		public string? DisplayName { get; set; }
		public string? GivenName { get; set; }
		public string? PreferredName { get; set; }
		public string? Surname { get; set; }

		public string? CompanyName { get; set; }
		public string? Mail { get; set; }
		public string? MobilePhone { get; set; }
		public string? UserType { get; set; }

		public string? StreetAddress { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Country { get; set; }
		public string? PostalCode { get; set; }

		public DateTimeOffset? CreatedDateTime { get; set; }
		public string? CreationType { get; set; }

	}
}

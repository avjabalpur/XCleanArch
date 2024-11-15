using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcdifyConnect.Application.DTOs
{
	public class CallRecordDto
	{
		public string? Id { get; set; }
		public DateTimeOffset? EndDateTime { get; set; }
		public DateTimeOffset? StartDateTime { get; set; }
		public string? JoinWebUrl { get; set; }
		public DateTimeOffset? LastModifiedDateTime { get; set; }
		public string? Type { get; set; }
		public string? OrganizerName { get; set; }
		public string? Duration { get; set; }
	}
}

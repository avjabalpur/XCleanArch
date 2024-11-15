using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Tokens;
using XcdifyConnect.Application.DTOs;
using XcdifyConnect.Application.Interfaces;
using XcdifyConnect.Common;
using XcdifyConnect.Domain.Services;
using System.Linq;

namespace XcdifyConnect.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IMicrosoftGraphService _microsoftGraphService;
		public UserService(IMicrosoftGraphService microsoftGraphService)
		{
			_microsoftGraphService = microsoftGraphService;
		}
		public async Task<List<UserDto>> GetAllUser()
		{
			var users = await _microsoftGraphService.GetUsersAsync();
			if (users != null) {
				return users
					.Select(x => new UserDto()
						{
							Id = x.Id,
							CompanyName = x.CompanyName,
							Surname = x.Surname,
							DisplayName = x.DisplayName,
							GivenName = x.GivenName,
							PreferredName = x.PreferredName,
							Birthday = x.Birthday,
							Mail = x.Mail,
							MobilePhone = x.MobilePhone,
							StreetAddress = x.StreetAddress,
							City = x.City,
							State = x.State,
							Country = x.Country,
							PostalCode = x.PostalCode,
							UserType = x.UserType,
							CreatedDateTime = x.CreatedDateTime,
							CreationType = x.CreationType
					})
					.ToList();
			}
			return null;
		}
	}
}
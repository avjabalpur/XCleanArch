using XcdifyConnect.Application.DTOs;

namespace XcdifyConnect.Application.Interfaces
{
	public interface IUserService
	{
		Task<List<UserDto>> GetAllUser();
	}
}
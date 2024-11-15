using Microsoft.AspNetCore.Mvc;
using XcdifyConnect.Application.Interfaces;

namespace XcdifyConnect.Presentation.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : BaseApiController
	{
		private readonly ILogger<UsersController> _logger;
		private readonly ICallRecordService _callRecordService;
		private readonly IUserService _userService;
		public UsersController(
			ILogger<UsersController> logger,
			IUserService userService,
			ICallRecordService callRecordService)
		{
			_logger = logger;
			_userService = userService;
			_callRecordService = callRecordService;
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetUsers()
		{
			var records = await _userService.GetAllUser();
			return Ok(records);
		}

		[HttpGet]
		[Route("{id}/calls")]
		public async Task<IActionResult> GetUserCalls(string id, DateTime? startDate = null, DateTime? endDate = null)
		{
			var records = await _callRecordService.GetUserCallRecordsAsync(id, startDate, endDate);
			return Ok(records);
		}
	}
}

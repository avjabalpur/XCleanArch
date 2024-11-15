using Microsoft.AspNetCore.Mvc;
using XcdifyConnect.Application.Interfaces;

namespace XcdifyConnect.Presentation.Controllers
{
	[Route("api/call-records")]
	[ApiController]
	public class CallRecordsController : BaseApiController
	{
		private readonly ILogger<CallRecordsController> _logger;
		private readonly ICallRecordService _callRecordService;

		public CallRecordsController(
			ILogger<CallRecordsController> logger,
			ICallRecordService callRecordService)
		{
			_logger = logger;
			_callRecordService = callRecordService;
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetAllCallRecords(DateTime? startDate = null, DateTime? endDate = null)
		{
			var records = await _callRecordService.GetCallRecordsAsync(startDate, endDate);
			return Ok(records);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetAllCallRecordDetails(string id)
		{
			var records = await _callRecordService.GetCallRecorDetailsAsync(id);
			return Ok(records);
		}
	}
}

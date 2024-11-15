using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace XcdifyConnect.Presentation.Controllers
{
	public class BaseApiController : ControllerBase
	{
		private const string BearerAuthPrefix = "Bearer ";

		internal string token { get { return GetAuthToken(); } }
		internal string currentUserId { get { return GetClaimFromToken("id"); } }
		internal string currentUserName { get { return GetClaimFromToken("userName"); } }

		private string GetAuthToken()
		{
			try
			{
				return Request.Headers["Authorization"].ToString().Substring(BearerAuthPrefix.Length);

			}
			catch
			{
				return "";
			}
		}

		private string GetClaimFromToken(string claimName)
		{
			try
			{
				var authTokent = GetAuthToken();
				var handler = new JwtSecurityTokenHandler();
				var token = handler.ReadJwtToken(authTokent);
				return token.Claims.First(c => c.Type.ToLower() == claimName.ToLower()).Value;
			}
			catch
			{
				return "";
			}
		}



	}
}


using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UrlHelperExtensions
    {
		public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme, string url)
		{
			//return urlHelper.Action(
			//	action: nameof(AccountController.ConfirmEmail),
			//	controller: "Account",
			//	values: new { userId, code },
			//	protocol: scheme,
			//	host: url + "/#");
			return null;
		}

		public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme, string url)
		{
			//return urlHelper.Action(
			//	action: nameof(AccountController.ResetPassword),
			//	controller: "Account",
			//	values: new { userId, code },
			//	protocol: scheme,
			//	host: url+"/#" );
			return null;
		}
	}
}

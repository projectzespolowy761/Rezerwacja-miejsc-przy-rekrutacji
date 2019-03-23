
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationPlaces.WebApp.Models;
using ReservationPlaces.WebApp.Services;
using System.Linq;
using Microsoft.Extensions.Configuration;
using ReservationPlaces.WebApplication.Models.AccountViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Security.Claims;

namespace ReservationPlaces.WebApp.Controllers
{
	[Authorize]
	[Route("[controller]/[action]")]
	public class AccountController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IEmailSender _emailSender;
		public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			IEmailSender emailSender,
			RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_signInManager = signInManager;
			_emailSender = emailSender;
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody]LoginViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			var errors = ModelState.Values.SelectMany(v => v.Errors);
			if (ModelState.IsValid)
			{
				// This doesn't count login failures towards account lockout
				// To enable password failures to trigger account lockout, set lockoutOnFailure: true
				var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
			    if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
				{
					ModelState.AddModelError(string.Empty, "Zły adres email,hasło lub email nie został potwierdzony");
					return BadRequest(ModelState);
				}
				var validCredentials = await _signInManager.UserManager.CheckPasswordAsync(user, model.Password);
				if (!validCredentials)
				{
					ModelState.AddModelError(string.Empty, "Zły adres email lub hasło");
					return BadRequest(ModelState);
				}

				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					var claims = new List<Claim>();

					var roles = await _userManager.GetRolesAsync(user);
					if(roles.Any()){
					if (roles[0]=="Administrator") {

						claims = new List<Claim>
						{
							new Claim(ClaimTypes.Name, user.UserName),
							new Claim(ClaimTypes.Role, "Administrator")
						};
					}
					}
				    claims = new List<Claim>
				    {
				        new Claim(ClaimTypes.NameIdentifier,user.Id),
				        new Claim(ClaimTypes.Role, "Default")
                    };

                  // var claim = await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier,user.Id));
					var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Common.ConstVal.SecurityKey));
					var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

					var tokeOptions = new JwtSecurityToken(
						issuer: Common.ConstVal.BaseAddress,
						audience: Common.ConstVal.BaseAddress,
						claims: claims,
						expires: DateTime.Now.AddMinutes(30),
						signingCredentials: signinCredentials
					);

					var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
					return Ok(new { Token = tokenString });

				}
				if (result.IsLockedOut)
				{
					ModelState.AddModelError(string.Empty, "User account locked out.");
					return BadRequest(ModelState);

				}
				else
				{
					ModelState.AddModelError(string.Empty, "Błąd podczas logowania. Spróbuj poźniej lub skontaktuj się z administratorem");
					return BadRequest(ModelState);

				}
			}
			ModelState.Clear();
			ModelState.AddModelError(string.Empty, "Zły adres email,hasło lub email nie został potwierdzony");
			// If we got this far, something failed, redisplay form
			return BadRequest(ModelState);
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Register([FromBody]RegisterViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{

					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

					var url = HttpContext.Request.Host.ToString();

					var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme, url);
					_emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

					//await _signInManager.SignInAsync(user, isPersistent: false);

					return Ok();
				}
					ModelState.AddModelError(string.Empty, "Podany adres jest już zarejestrowany ");
			}

			// If we got this far, something failed, redisplay form
			return BadRequest(ModelState);
		}



		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmail(string userId, string code)
		{
			if (userId == null || code == null)
			{
				return BadRequest();
			}
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				throw new ApplicationException($"Unable to load user with ID '{userId}'.");
			}
			var result = await _userManager.ConfirmEmailAsync(user, code);
			return Ok();
		}



		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
				{
					// Don't reveal that the user does not exist or is not confirmed
					ModelState.AddModelError(string.Empty, "Użytkownik nie istnieje lub nie jest potwierdzony");
					return BadRequest(ModelState);
				}

				// For more information on how to enable account confirmation and password reset please
				// visit https://go.microsoft.com/fwlink/?LinkID=532713
				var code = await _userManager.GeneratePasswordResetTokenAsync(user);

				var url = HttpContext.Request.Host.ToString();

				var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme, url);
				//callbackUrl += "&email=" + user.Email;

				_emailSender.SendEmailForgetPasswordAsync(model.Email, callbackUrl);

				return Ok();
			}

			// If we got this far, something failed, redisplay form
			return BadRequest(ModelState);
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var user = await _userManager.FindByIdAsync(model.UserId);

			if (user == null)
			{
				// Don't reveal that the user does not exist
				ModelState.AddModelError(string.Empty, "Użytkownik nie istnieje lub nie jest potwierdzony");
				return BadRequest(ModelState);
			}
			var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
			if (result.Succeeded)
			{
				return Ok();
			}
			return BadRequest(ModelState);
		}

	}
}
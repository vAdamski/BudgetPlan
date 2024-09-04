using System.Web;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using DuendeIdentityServer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuendeIdentityServer.Pages.Account.Register;

public class Index : PageModel
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly IIdentityServerInteractionService _interaction;

	public Index(
		IIdentityServerInteractionService interaction,
		IAuthenticationSchemeProvider schemeProvider,
		IIdentityProviderStore identityProviderStore,
		IEventService events,
		UserManager<ApplicationUser> userManager,
		SignInManager<ApplicationUser> signInManager)
	{
		_userManager = userManager;
		_interaction = interaction;
	}

	[BindProperty] public RegisterViewModel RegisterVm { get; set; }

	public async Task<IActionResult> OnGetAsync(string returnUrl)
	{
		await BuildModelAsync(returnUrl);
		RegisterVm.ReturnUrl = returnUrl; // Preserve the entire ReturnUrl with all parameters
		return Page();
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (RegisterVm.ButtonAction != "register")
		{
			var context = await _interaction.GetAuthorizationContextAsync(RegisterVm.ReturnUrl);
			if (context != null)
			{
				await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);

				if (context.IsNativeClient())
				{
					return this.LoadingPage(RegisterVm.ReturnUrl);
				}

				return Redirect(RegisterVm.ReturnUrl);
			}
			else
			{
				return Redirect("~/");
			}
		}

		if (!ModelState.IsValid)
		{
			await BuildModelAsync(RegisterVm.ReturnUrl);
			return Page();
		}

		var userExist = await _userManager.FindByEmailAsync(RegisterVm.Email);
		if (userExist != null)
		{
			ModelState.AddModelError("", "Username already exists");
			await BuildModelAsync(RegisterVm.ReturnUrl);
			return Page();
		}

		var user = new ApplicationUser
		{
			Id = Guid.NewGuid().ToString(),
			FirstName = RegisterVm.FirstName,
			NormalizedFirstName = RegisterVm.FirstName.Normalize().ToUpper(),
			LastName = RegisterVm.LastName,
			NormalizedLastName = RegisterVm.LastName.Normalize().ToUpper(),
			UserName = RegisterVm.Username,
			NormalizedUserName = RegisterVm.Username.Normalize().ToUpper(),
			Email = RegisterVm.Email,
			NormalizedEmail = RegisterVm.Email.Normalize().ToUpper(),
			EmailConfirmed = true,
			PasswordHash = Guid.NewGuid().ToString()
		};

		var createUserResponse = await _userManager.CreateAsync(user, RegisterVm.Password);

		if (!createUserResponse.Succeeded)
		{
			ModelState.AddModelError("", "Something went wrong");
			await BuildModelAsync(RegisterVm.ReturnUrl);
			return Page();
		}

        return Redirect(RegisterVm.ReturnUrl);
    }

	private async Task BuildModelAsync(string returnUrl)
	{
		RegisterVm = new RegisterViewModel()
		{
			ReturnUrl = returnUrl
		};
	}
}
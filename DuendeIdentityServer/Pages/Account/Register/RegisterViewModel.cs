using System.ComponentModel.DataAnnotations;

namespace DuendeIdentityServer.Pages.Account.Register;

public class RegisterViewModel
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(25, ErrorMessage = "Must be between 3 and 25 characters", MinimumLength = 3)]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(25, ErrorMessage = "Must be between 3 and 25 characters", MinimumLength = 3)]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Username is required")]
    [StringLength(25, ErrorMessage = "Must be between 3 and 25 characters", MinimumLength = 3)]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
    [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Confirm Password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    public string ReturnUrl { get; set; }
    public string ButtonAction { get; set; }
}
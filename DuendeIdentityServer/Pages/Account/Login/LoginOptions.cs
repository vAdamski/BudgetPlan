namespace DuendeIdentityServer.Pages.Account.Login;

public class LoginOptions
{
    public static bool AllowLocalLogin = true;
    public static bool AllowRememberLogin = true;
    public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);
    public static string InvalidCredentialsErrorMessage = "Niepoprawny login lub hasło";
}
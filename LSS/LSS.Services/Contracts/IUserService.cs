namespace LSS.Services.Contracts
{
    public interface IUserService
    {
        string RegisterUser(params string[] userDetails);

        string Login(params string[] userDetails);

        string LogOut();

        string ChangeUsername(string newUsername);

        string ChangePassword(params string[] passwordDetails);

        string DeleteAccount();
    }
}

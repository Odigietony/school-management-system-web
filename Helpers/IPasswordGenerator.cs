namespace SchoolManagementSystem.Helpers
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(int length);
        string GenerateUsernameFromEmail(string emailAddress);
    }
}
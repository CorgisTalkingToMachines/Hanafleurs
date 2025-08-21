namespace API.Domain.Services
{
    public interface IPasswordHashingService
    {
        string HashPassword(string password);
        bool VerifyCorrespondingPasswordWithStoredHashedPassword(string password, string hashedPassword);
    }
}

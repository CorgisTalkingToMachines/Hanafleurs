namespace API.Domain.Services
{
    public interface IPasswordHashingService
    {
        public string HashPassword(string password);
        public bool VerifyCorrespondingPasswordWithStoredHashedPassword(string password, string hashedPassword);
    }
}

namespace Wing_Fleet_Manager.Helpers
{
    public class PasswordHelper
    {
        public static string PasswordHasher(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string HashPassword,string Password)
        {
            return BCrypt.Net.BCrypt.Verify(Password, HashPassword);
        }
    }
}

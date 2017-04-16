namespace SimpleTimeTracker.Core.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string clearTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(clearTextPassword);
        }

        public static bool IsMatch(string clearTextPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(clearTextPassword, hashedPassword);
        }
    }
}

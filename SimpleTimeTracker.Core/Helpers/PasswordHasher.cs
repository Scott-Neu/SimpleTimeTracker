using System;

namespace SimpleTimeTracker.Core.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string clearTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(clearTextPassword, BCrypt.Net.BCrypt.GenerateSalt(10));
        }

        public static bool IsMatch(string clearTextPassword, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(clearTextPassword, hashedPassword);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

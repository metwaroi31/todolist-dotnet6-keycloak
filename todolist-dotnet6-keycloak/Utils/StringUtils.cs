using System;

namespace todolist_dotnet6_keycloak.Utils
{
    public class StringUtils
    {
        private static Random random = new Random();
        public static String generateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

        }
    }
}

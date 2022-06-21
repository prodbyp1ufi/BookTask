using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TaskBookAPI.Utils
{
    public class AuthOptions
    {
        public const string ISSUER = "MyTestTaskAPI"; 
        public const string AUDIENCE = "MyTestTaskClient"; 
        const string KEY = "books_testTask_topsecretkey";  
        public const int LIFETIME = 1; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
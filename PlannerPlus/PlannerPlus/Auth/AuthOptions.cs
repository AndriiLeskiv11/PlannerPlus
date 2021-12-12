using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace PlannerPlus.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "PlannerServer"; 
        public const string AUDIENCE = "PlannerClient"; 
        const string KEY = "PlannerSecretKey"; 
        public const int LIFETIME = 60; 

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

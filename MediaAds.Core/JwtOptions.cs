using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaAds.Core
{
    public class JwtOptions
    {
        public const string ISSUER = "MediaAds";
        public const string AUDIENCE = "http://localhost:4200/";
        const string KEY = "secretkey12353!qlwkdjfsklgjlk10927836r42089jhkdjkflwejdbncqwukjdghu21pduihashgJHJHKGJKHGWJHr;ui23yfudkejhgpiu";
        public const int LIFETIME = 60;
        public static SymmetricSecurityKey SecurityKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}

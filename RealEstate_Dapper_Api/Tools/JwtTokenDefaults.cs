﻿namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenDefaults
    {
        //bazı varsayılan değerler girilmesi
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "REALestate..0102030405Asp.NetCore8.0.1+-*/";
        public const int Expire = 5;
    }
}

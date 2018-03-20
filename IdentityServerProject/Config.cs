﻿using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServerProject
{
    public class Config
    {
        public Config()
        {
            
        }

        public static IEnumerable<ApiResource> GetApiResource(){
            return new List<ApiResource>(){
                 new ApiResource("api1","MyApi")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                 new Client
                 {
                     ClientId = "client",
                
                     // no interactive user, use the clientid/secret for authentication
                     AllowedGrantTypes = GrantTypes.ClientCredentials,
                
                     // secret for authentication
                     ClientSecrets =
                     {
                         new Secret("secret".Sha256())
                     },
                
                     // scopes that client has access to
                     AllowedScopes = { "api1" }
                 }
             };
        }


    }
}

using System;
using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

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
                     ClientId = "ro.client",
                
                     // no interactive user, use the clientid/secret for authentication
                     //AllowedGrantTypes = GrantTypes.ClientCredentials,
                     AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                
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
        public static List<TestUser> GetUsers()
        {
          return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }

    }
}

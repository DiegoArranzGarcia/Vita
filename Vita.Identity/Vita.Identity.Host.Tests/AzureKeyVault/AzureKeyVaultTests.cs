using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using System;
using System.Security.Cryptography;
using Xunit;
using Microsoft.Azure.Services.AppAuthentication;

namespace Vita.Identity.Host.Tests
{
    public class AzureKeyVaultTests
    {
        [Fact]
        public void RSAKeyTest()
        {
            var defaultAzureCredential = new DefaultAzureCredential();

            var keyClient = new KeyClient(new Uri("{{your kv url}}"), defaultAzureCredential);
            Response<KeyVaultKey> response = keyClient.GetKey("SingInCredentialsKey");

            RSA rsa = response.Value.Key.ToRSA();

            Assert.NotNull (response.Value.Properties.Version);
        }
    }
}

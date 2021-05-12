using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using System;
using System.Security.Cryptography;
using Xunit;
using Microsoft.Azure.Services.AppAuthentication;
using Azure.Security.KeyVault.Certificates;

namespace Vita.Identity.Host.Tests
{
    public class AzureKeyVaultTests
    {
        [Fact]
        public void RSAKeyTest()
        {
            var keyClient = new KeyClient(new Uri("{{your keyvault uri}}"), new DefaultAzureCredential());
            Response<KeyVaultKey> response = keyClient.GetKey("SingInCredentialsKey");

            RSA rsa = response.Value.Key.ToRSA();

            Assert.NotNull (response.Value.Properties.Version);
        }        
        
        [Fact]
        public void CertificateTest()
        {
            var keyClient = new CertificateClient(new Uri("{{your keyvault uri}}"), new DefaultAzureCredential());
            Response<KeyVaultCertificateWithPolicy> response = keyClient.GetCertificate("SignInCredentialsCert");

            Assert.NotNull (response.Value.Properties.Version);
        }
    }
}

namespace SSToolkit.VividCryptography.Tests
{
    using SSToolkit.VividCryptography;
    using Xunit;

    public class EncryptorTests
    {
        [Fact]
        public void EncryptDecrypt_Test()
        {
            string plainText = "4242424242424242";
            var crypto = new Encryptor("ASDasd@!#!@#SDASD@E!@D!WDQDASDADR#%^GFGHGSDGTJMUIP12312541235423");
            var cipherText = crypto.Encrypt(plainText);
            var result = crypto.Decrypt(cipherText);
            Assert.Equal(result, plainText);

            var cipherText2 = crypto.Encrypt(plainText);
            var result2 = crypto.Decrypt(cipherText2);
            Assert.Equal(result2, plainText);
        }
    }
}

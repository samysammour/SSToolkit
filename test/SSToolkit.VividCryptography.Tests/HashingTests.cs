namespace SSToolkit.VividCryptography.Tests
{
    using SSToolkit.VividCryptography;
    using Xunit;
    
    public class HashingTests
    {
        [Fact]
        public void GetSaltTest()
        {
            var hashing = new Hashing();
            var salt = hashing.GetSalt();

            Assert.NotNull(salt);
            Assert.True(salt.Length == 32);

            var repeatSalt = hashing.GetSalt();
            Assert.NotEqual(salt, repeatSalt);
        }

        [Fact]
        public void GetCipherTextTest()
        {
            string plainText = "Hello world!";
            var hashing = new Hashing();
            // not empty
            var salt = hashing.GetSalt();
            var cipher = hashing.GetCipherText(plainText, salt);
            Assert.True(!string.IsNullOrEmpty(cipher));
            Assert.True(cipher.Length == 512);

            // the same result always
            var repeatCipher = hashing.GetCipherText(plainText, salt);
            Assert.Equal(cipher, repeatCipher);

            // cannot be duplicated
            var anotherCipher = hashing.GetCipherText(plainText + "s", salt);
            Assert.NotEqual(cipher, anotherCipher);

            // not the same with new salt
            var newSalt = hashing.GetSalt();
            var newCipher = hashing.GetCipherText(plainText, newSalt);
            Assert.NotEqual(cipher, newCipher);
        }

        [Fact]
        public void CompateHashTest()
        {
            string plainText = "Hello world!";
            var hashing = new Hashing();
            // match
            var salt = hashing.GetSalt();
            var oldHash = hashing.GetCipherText(plainText, salt);
            Assert.True(hashing.CompareHash(plainText, oldHash, salt));

            // different salt
            var anotherSalt = hashing.GetSalt();
            Assert.False(hashing.CompareHash(plainText, oldHash, anotherSalt));

            // different hash
            var anotherHash = hashing.GetCipherText(plainText, anotherSalt);
            Assert.False(hashing.CompareHash(plainText, anotherHash, salt));
        }
    }
}

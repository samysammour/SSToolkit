# VividCryptography
VividCryptography: Encrypt/Decrypt and Hash

Encryptor
---
- Use a 64Byte key to encrypt and decrypt using Aes algorithm and Rfc2898Derive to create random bytes.


---
Hashing
---
- Create a hash using Pbkdf2 and iterate by default 10000 time adding a salt to the hash.
- Hash a plaintext and compare it with old hash.

---
Usage:
--- 

Encrypt/Decrypt
```csharp
var crypto = new Encryptor(your_key);
string plainText = "4242424242424242";
var cipherText = crypto.Encrypt(plainText);
var plainText = crypto.Decrypt(cipherText);
```

Hashing
```csharp
var hashing = new Hashing();
string plainText = "Hello world!";
var salt = hashing.GetSalt();
var hash = hashing.GetCipherText(plainText, salt);
```

Hashing constructor parameters are:

Parameter | Default value
:---: | :---:
hashSize  | 256
saltSize  | 32
iteration | 10000

To compare hashing
```csharp
hashing.CompareHash(plainText, hash, salt)
```

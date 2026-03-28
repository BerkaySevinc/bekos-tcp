using System.Security.Cryptography;


namespace BekoS.Tcp;


public class TcpEncryptionOptions
{
    public bool UseIV { get; set; }

    public int KeySize { get; set; } = 256;

    public PaddingMode Padding { get; set; } = PaddingMode.PKCS7;

    public string? Password { get; set; }
    public string? PasswordDerivationSalt { get; set; }
}

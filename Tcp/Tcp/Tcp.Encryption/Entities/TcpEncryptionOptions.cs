using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// TODO: should key size be readonly 256?
// TODO: should iterations & hashalgoritm & aespaddingmode be added as prop?


namespace BekoS.Tcp.Encryption;


public class TcpEncryptionOptions
{
    public bool UseIV { get; set; }

    public int KeySize { get; set; } = 256;
    public int BlockSize { get; set; } = 128;

    public PaddingMode Padding { get; set; } = PaddingMode.PKCS7;

    public string? Password { get; set; }
    public string? PasswordDerivationSalt { get; set; }
}

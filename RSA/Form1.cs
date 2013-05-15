using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Security.Cryptography;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Utilities.IO.Pem;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Crypto.Encodings;
namespace RSA
{
    public partial class Form1 : Form
    {
        static string decipheredText;
        static UTF8Encoding utf8enc = new UTF8Encoding();
        static IAsymmetricBlockCipher cipher;
        static RsaKeyPairGenerator rsaKeyPairGnr;
        static RsaKeyParameters publicKey;
        static RsaKeyParameters privateKey;
        static Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair keyPair;
        static byte[] cipheredBytes; // przechowuje po szyfrowaniu i do szyfrowania!
        static byte[] deciphered; // odszyfrowane
        static byte[] inputBytes; // dla wiadomosci do zaszyfrowania
        //for OAEP
        static SHA256Managed hash = new SHA256Managed();
        static SecureRandom randomNumber = new SecureRandom();
        static byte[] encodingParam = hash.ComputeHash(Encoding.UTF8.GetBytes(randomNumber.ToString()));

        public Form1()
        {
            InitializeComponent();
            //Zabezpieczenie ;)
            lbCrypto.SelectedIndex = 0;
            lbSign.SelectedIndex = 0;
        }

        private void btnImportKeys_Click(object sender, EventArgs e)
        {
            privateKey = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(tbPrivKey.Text));
            publicKey = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(tbPubKey.Text));
        }

        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            // RSAKeyPairGenerator generates the RSA Key pair based on the random number and strength of key required
            rsaKeyPairGnr = new RsaKeyPairGenerator();
            rsaKeyPairGnr.Init(new Org.BouncyCastle.Crypto.KeyGenerationParameters(new SecureRandom(), 2048));
            keyPair = rsaKeyPairGnr.GenerateKeyPair();

            publicKey = (RsaKeyParameters)keyPair.Public;
            privateKey = (RsaKeyParameters)keyPair.Private;
            // Extracting the public key from the pair
            /*publicKey = (RsaKeyParameters)keyPair.Public;
            string pubex = Convert.ToString(publicKey.Exponent);
            string pubmod = Convert.ToString(publicKey.Modulus);
            tbPubKey.Text = pubex + pubmod;

            // Extracting the private key from the pair
            privateKey = (RsaKeyParameters)keyPair.Private;
            string privex = Convert.ToString(privateKey.Exponent);
            tbPrivKey.Text = privex;*/

            SubjectPublicKeyInfo info = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(keyPair.Public);
            byte[] ret = info.GetEncoded();
            tbPubKey.Text = Convert.ToBase64String(ret);

            PrivateKeyInfo info2 = PrivateKeyInfoFactory.CreatePrivateKeyInfo(keyPair.Private);
            byte[] privRet = info2.GetEncoded();
            tbPrivKey.Text = Convert.ToBase64String(privRet);


        }

        static void rsaEngine(int flag)
        {
            if (flag == 0)
            {
                // Creating the RSA algorithm object
                cipher = new RsaEngine();
            }
            else
            {
                cipher = new OaepEncoding(new RsaEngine(), new Sha256Digest(), encodingParam);
            }
        }

        static void encrypt(int lenght)
        {
            // Initializing the RSA object for Encryption with RSA public key. Remember, for encryption, public key is needed
            cipher.Init(true, publicKey);

            //Encrypting the input bytes
            cipheredBytes = cipher.ProcessBlock(inputBytes, 0, lenght);
        }

        private void btnCrypt_Click(object sender, EventArgs e)
        {
            rsaEngine(lbCrypto.SelectedIndex);
            inputBytes = utf8enc.GetBytes(tbInput.Text);
            encrypt(tbInput.TextLength);

            //Bajerek do pokazania zaszyfrowanej rzeczy jakos ladnie
            tbInput.Text = Convert.ToBase64String(cipheredBytes);
        }

        static void decrypt()
        {
            cipher.Init(false, privateKey);
            deciphered = cipher.ProcessBlock(cipheredBytes, 0, cipheredBytes.Length);
            decipheredText = utf8enc.GetString(deciphered);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            rsaEngine(lbCrypto.SelectedIndex);
            cipheredBytes = Convert.FromBase64String(tbInput.Text);
            decrypt();
            tbInput.Text = decipheredText;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            // http://stackoverflow.com/questions/8830510/c-sharp-sign-data-with-rsa-using-bouncycastle

            /* Make the key */
            //RsaKeyParameters key = MakeKey(privateModulusHexString, privateExponentHexString, true);

            /* Init alg */
            ISigner sig;
            switch(lbSign.SelectedIndex)
            {
                //http://www.apps.ietf.org/rfc/rfc3447.html#sec-9.2
                case 0:
                    sig = SignerUtilities.GetSigner("RSA");
                    break;
                //http://www.apps.ietf.org/rfc/rfc3447.html#sec-9.1
                case 1:
                    sig = SignerUtilities.GetSigner("SHA1withRSA");
                    break;
                case 2:
                    sig = SignerUtilities.GetSigner("SHA1withRSA/ISO9796-2");
                    break;
                
                default:
                    sig = SignerUtilities.GetSigner("RSA");
                    break;
            }

            /* Populate key */
            sig.Init(true, privateKey);

            /* Get the bytes to be signed from the string */
            var bytes = Encoding.UTF8.GetBytes(tbInput.Text);

            /* Calc the signature */
            sig.BlockUpdate(bytes, 0, bytes.Length);
            byte[] signature = sig.GenerateSignature();

            /* Base 64 encode the sig so its 8-bit clean */
            var signedString = Convert.ToBase64String(signature);
            tbOutput.Text = signedString;
        }

        private void butVerify_Click(object sender, EventArgs e)
        {

            /* Make the key */
            //RsaKeyParameters key = MakeKey(publicModulusHexString, publicExponentHexString, false);

            /* Init alg */
            ISigner signer;
            switch (lbSign.SelectedIndex)
            {
                //http://www.apps.ietf.org/rfc/rfc3447.html#sec-9.2
                case 0:
                    signer = SignerUtilities.GetSigner("RSA");
                    break;
                //http://www.apps.ietf.org/rfc/rfc3447.html#sec-9.1
                case 1:
                    signer = SignerUtilities.GetSigner("SHA1withRSA");
                    break;

                case 2:
                    signer = SignerUtilities.GetSigner("SHA1withRSA/ISO9796-2");
                    break;

                default:
                    signer = SignerUtilities.GetSigner("RSA");
                    break;
            }

            /* Populate key */
            signer.Init(false, publicKey);

            /* Get the signature into bytes */
            var expectedSig = Convert.FromBase64String(tbOutput.Text);

            /* Get the bytes to be signed from the string */
            var msgBytes = Encoding.UTF8.GetBytes(tbInput.Text);

            /* Calculate the signature and see if it matches */
            signer.BlockUpdate(msgBytes, 0, msgBytes.Length);

            if (signer.VerifySignature(expectedSig))
            {
                MessageBox.Show("Poprawny", "Weryfikacja");
            }
            else
            {
                MessageBox.Show("niepoprawny", "Weryfikacja");
            }
            
        }


    }
}

/// Rowan Kill - CNA 475
/// 3/28/17
/// Purpose: This program is meant to hash the location of a file by either taking
///     a file name (example.txt) as input, which the program assumes will be local to the
///     executable for this program, or taking a path to a file (including the file name).
/// It will create all files and directories if they don't already exist.
/// The program copies the input file to a new directory on the C drive
///     that is called CNA Files. The original file is not moved, only copied.
///     
/// I could have made this with less functions, but I chose this messy program design
///    in order to practice with C# by programming in a different style than I usually do

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;                      //added autoamtically, module wasn't provided in notes
using System.Text;
using System.Threading.Tasks;           //added automatically
using System.Windows.Forms;
using System.Security.Cryptography;    //added manually
using System.IO;                       //added manually

namespace Hash_KillRowan_Project4
{
    public partial class frmHash : Form
    {
        //counter used to count number of times a button is clicked
        private int countHashBtnClicks;

        public frmHash()
        {
            InitializeComponent();
        } //this just initializes the form, basically creates the form object

        private void frmHash_Load(object sender, EventArgs e)
        {
            countHashBtnClicks = 0;
        } //variable to initialize when form loads

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        } //closes the form - 'this' refers to class Client_KillRowanProject3.frmHash

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFileName.Clear();
            txtHashPathResult.Clear();
            txtHashResult.Clear();
        } //clear all text boxes but leave selection in combobox for easy reuse

        private void btnHash_Click(object sender, EventArgs e)
        {
            //increment counter to keep track of # times button is clicked
            countHashBtnClicks++;

            //warn user if they create a handful of folders
            //prevent user from creating >= 70 folders by holding Enter
            if (countHashBtnClicks % 10 == 0)
            {
                var result = MessageBox.Show("You have already created a handful of folders on your hard drive." +
                    "\nThis program creates a new folder for every file that's hashed." +
                    "\nClick OK to continue and create more folders." +
                    "\nClick Cancel to stop creating folders and stop hashing the current file.",
                    "Warning: Multiple Folders Created",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                //determine which button user pressed on result msgBox and act accordingly
                switch (result)
                {
                    case (DialogResult.OK):
                        //create another folder and hash the input normally
                        break;
                    case (DialogResult.Cancel):
                        //clear text boxes so user can't ignore warning by holding Enter
                        //return so hash algorithms don't run
                        btnReset_Click(sender, e);
                        return;
                }//end switch
            }//end if
            //prevent user from creating too many folders, 69 % 5 != 0 so if won't catch it
            else if (countHashBtnClicks == 69)
            {
                var result = MessageBox.Show("This program has created almost 70 folders on this hard drive." +
                    "\nTo prevent too many folders from being created, the program will now reset.",
                    "Error: Too Many Folders Created", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                //if user selects retry, open messagebox again (prevents holding enter and ignoring warnings)
                if (result == DialogResult.Retry)
                {
                    //decrement in order to keep counter at 69 and prevent it from going to 70
                    //because 70 % 5 == 0 so the outer if statement would catch it
                    //could reset form here, but I want user to be aware that too many
                        //folders have been created and make sure it can't be missed
                    countHashBtnClicks--;
                    return;
                }//end nested if

                //reset form, set counter to 0 and have user start over
                countHashBtnClicks = 0;
                btnReset_Click(sender, e);
                return;
            }//end if/else if

            //make sure user has data in file name txtbox + has chosen an algorithm
            if ((txtFileName.Text == "") || (cboAlgorithm.Text == String.Empty))
            {
                MessageBox.Show("You should enter a file name that will be hashed." +
                    "\nIn theory, it's possible to hash an empty string, but that's not useful." + 
                    "\nAlso, make sure you've selected an algorithm to use from the menu.",
                    "Error: Missing File Name or Algorithm Choice",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //decrement button click counter because folder wasn't created
                countHashBtnClicks--;
                return;
            }
            //create variables that apply to all algorithms
            string menuItem = "";
            string fileName = "";
            string HashValue;

            //trim unnecessary characters from file name
            txtFileName.Text = txtFileName.Text.Trim();
            fileName = txtFileName.Text;

            //make sure to get only fileName in case user enters a full path
            //by finding index of fileName in path
            string fileNameWithoutPath = fileName;
            int fileNameIndexInFileName = fileNameWithoutPath.LastIndexOf('\\');
            if (fileNameIndexInFileName != -1)
            {
                fileNameWithoutPath = txtFileName.Text.Remove(0, fileNameIndexInFileName);
                fileNameWithoutPath = fileNameWithoutPath.Replace('\\', ' ').Trim();
            }

            //determine which algorithm was chosen from drop-down menu
            menuItem = cboAlgorithm.SelectedItem.ToString();

            //send file name to the hash algorithm chosen in drop-down
            //output to two output txt boxes
            switch (menuItem)
            {
                case "AES":
                    HashValue = GetAESHash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "DES":
                    HashValue = GetDESHash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "TripleDES":
                    HashValue = GetAESHash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "MD5":
                    HashValue = GetMD5Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "RC2":
                    HashValue = GetRC2Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "Rijndael":
                    HashValue = GetRijndaelHash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "RIPEMD160":
                    HashValue = GetRIPEMD160Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "SHA1":
                    HashValue = GetSHA1Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "SHA256":
                    HashValue = GetSHA256Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "SHA384":
                    HashValue = GetSHA384Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "SHA512":
                    HashValue = GetSHA512Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "HMAC-MD5":
                    HashValue = GetHMACMD5Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "HMAC-RIPEMD160":
                    HashValue = GetHMACRIPEMD160Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "HMAC-SHA1":
                    HashValue = GetHMACSHA1Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "HMAC-SHA256":
                    HashValue = GetHMACSHA256Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "HMAC-SHA384":
                    HashValue = GetHMACSHA384Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
                case "HMAC-SHA512":
                    HashValue = GetHMACSHA512Hash(fileNameWithoutPath);
                    txtHashResult.Text = HashValue.ToString();
                    txtHashPathResult.Text = "C:\\CNA Files\\" + HashValue.ToString() + "\\" + fileNameWithoutPath;
                    break;
            } //end switch

            //create file if it doesn't exist
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }//end if

            //create path for hashed folders
            //first need to create C:\\CNA Files if it doesn't exist
            //then need to create txtHashPath.Text folder in CNA Files fodler
            int fileNameIndexInHashPath = txtHashPathResult.Text.Length - fileNameWithoutPath.Length;
            string pathWithoutFileName = txtHashPathResult.Text.Remove(fileNameIndexInHashPath);
            pathWithoutFileName.Trim();
            if (!Directory.Exists(pathWithoutFileName))
            {
                Directory.CreateDirectory(pathWithoutFileName);
            }//end if

            //copy file to new hashed path and overwrite it if one exists at path
            File.Copy(fileName, txtHashPathResult.Text.Trim(), true);
        } //computes hash value of folder name containing input file name

        private static string GetAESHash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            Aes hashString = new AesCryptoServiceProvider();

            //generate a weak KEY and Initialization Vector for the hash algorithm
            hashString.GenerateKey();
            hashString.GenerateIV();
            ICryptoTransform encryptor = hashString.CreateEncryptor(hashString.Key, hashString.IV);
            string Str = "";

            //compute hash with AES module and format output as string
            //convert bytes in HashResult to string values
            HashResult = encryptor.TransformFinalBlock(msg, 0, msg.Length);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetDESHash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            DES hashString = new DESCryptoServiceProvider();

            //generate a weak KEY and Initialization Vector for the hash algorithm
            hashString.GenerateKey();
            hashString.GenerateIV();
            ICryptoTransform encryptor = hashString.CreateEncryptor(hashString.Key, hashString.IV);
            string Str = "";

            //compute hash with DES module and format output as string
            //convert bytes in HashResult to string values
            HashResult = encryptor.TransformFinalBlock(msg, 0, msg.Length);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetTripleDESHash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            TripleDES hashString = new TripleDESCryptoServiceProvider();

            //generate a weak KEY and Initialization Vector for the hash algorithm
            hashString.GenerateKey();
            hashString.GenerateIV();
            ICryptoTransform encryptor = hashString.CreateEncryptor(hashString.Key, hashString.IV);
            string Str = "";

            //compute hash with TripleDES module and format output as string
            //convert bytes in HashResult to string values
            HashResult = encryptor.TransformFinalBlock(msg, 0, msg.Length);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetMD5Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            MD5 hashString = new MD5CryptoServiceProvider();
            string Str = "";
            
            //compute hash with MD5 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetRC2Hash(string text)
        {

            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            RC2 hashString = new RC2CryptoServiceProvider();

            //generate a weak KEY and Initialization Vector for the hash algorithm
            hashString.GenerateKey();
            hashString.GenerateIV();
            ICryptoTransform encryptor = hashString.CreateEncryptor(hashString.Key, hashString.IV);
            string Str = "";

            //compute hash with RC2 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = encryptor.TransformFinalBlock(msg, 0, msg.Length);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetRijndaelHash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            Rijndael hashString = RijndaelManaged.Create();

            //generate a weak KEY and Initialization Vector for the hash algorithm
            hashString.GenerateKey();
            hashString.GenerateIV();
            ICryptoTransform encryptor = hashString.CreateEncryptor(hashString.Key, hashString.IV);
            string Str = "";

            //compute hash with Rijndael module and format output as string
            //convert bytes in HashResult to string values
            HashResult = encryptor.TransformFinalBlock(msg, 0, msg.Length);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetRIPEMD160Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            RIPEMD160 hashString = RIPEMD160Managed.Create();
            string Str = "";

            //compute hash with RIPEMD160 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetSHA1Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            SHA1 hashString = new SHA1CryptoServiceProvider();
            string Str = "";

            //compute hash with SHA1 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetSHA256Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            SHA256 hashString = new SHA256CryptoServiceProvider();
            string Str = "";

            //compute hash with SHA256 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetSHA384Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            SHA384 hashString = new SHA384CryptoServiceProvider();
            string Str = "";

            //compute hash with SHA384 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetSHA512Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            SHA512 hashString = new SHA512CryptoServiceProvider();
            string Str = "";

            //compute hash with SHA512 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetHMACMD5Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            HMACMD5 hashString = new HMACMD5();
            string Str = "";

            //compute hash with HMACMD5 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetHMACRIPEMD160Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            HMACRIPEMD160 hashString = new HMACRIPEMD160();
            string Str = "";

            //compute hash with HMACRIPEMD160 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetHMACSHA1Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            HMACSHA1 hashString = new HMACSHA1();
            string Str = "";

            //compute hash with HMACSHA1 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetHMACSHA256Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            HMACSHA256 hashString = new HMACSHA256();
            string Str = "";

            //compute hash with HMACSHA256 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetHMACSHA384Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            HMACSHA384 hashString = new HMACSHA384();
            string Str = "";

            //compute hash with HMACSHA384 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

        private static string GetHMACSHA512Hash(string text)
        {
            //create variables for computing hash and making it a string
            UnicodeEncoding UniCode = new UnicodeEncoding();
            byte[] HashResult;
            byte[] msg = UniCode.GetBytes(text);
            HMACSHA512 hashString = new HMACSHA512();
            string Str = "";

            //compute hash with HMACSHA512 module and format output as string
            //convert bytes in HashResult to string values
            HashResult = hashString.ComputeHash(msg);
            foreach (byte x in HashResult)
            {
                Str += String.Format("{0:x2}", x);
            }

            //clear excess resource usage
            hashString.Clear();
            return Str;
        } //compute hash from arguments and return hash value as string

    } //end frmHash : Form
} //end Hash_KillRowan_Project4

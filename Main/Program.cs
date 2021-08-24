using System;
using System.Security.Cryptography;
using System.IO;
using Encryption;
using System.IO.Compression;
using System.Linq;

namespace Main
{


    class Program
    {


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static void Main(string[] args)
        {
            EncryptDLL yeboi = new EncryptDLL();
            string datafolder = @".\Data";
            string datafolder1 = @".\Data\Secured.zip";
            string outputdata = @".\DataZip\Encryptdit.zip";
            string olddata = @".\DataZip\OLD.zip";
            string SecuredData = @".\Secured\Data.txt";
            string DecryptedData = @".\Decrypt\Data.zip";
            System.IO.DirectoryInfo datafol = new DirectoryInfo(@".\Data");
            if (File.Exists(outputdata)){
                string oldname = RandomString(20)+".zip";
                Console.WriteLine("Er is een oude zip gevonden! Hij word renamed naar " + oldname);
                File.Move(outputdata, @".\DataZip\"+oldname);
                File.Delete(outputdata);
            }
            ZipFile.CreateFromDirectory(datafolder, outputdata);
            yeboi.FileEncrypt(outputdata, "noob");
            


            
        }




    }
}

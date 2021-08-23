using System;
using System.Security.Cryptography;
using System.IO;
using Encryption;
using System.IO.Compression;
namespace Main
{


    class Program
    {




        static void Main(string[] args)
        {
            EncryptDLL encryptie = new EncryptDLL();


            Console.WriteLine("Bestand word gezipt");
            
            
            // VAR VOOR DATA PATHS
            string datafolder = @".\Data";
            string datafolder1 = @".\Data\Secured.zip";
            string outputdata = @".\DataZip\Encryptdit.zip";
            string SecuredData = @".\Secured\Data.txt";
            string DecryptedData = @".\Decrypt\Data.zip";
            System.IO.DirectoryInfo datafol = new DirectoryInfo(@".\Data");


            if (File.Exists(outputdata)) { File.Delete(outputdata); }
            ZipFile.CreateFromDirectory(datafolder, outputdata);
            // Verwijderd Alle UnEncrypted Shit
            encryptie.EncryptFile(outputdata, SecuredData);
            File.Copy(SecuredData, datafolder1);
            foreach (FileInfo file in datafol.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in datafol.GetDirectories())
            {
                dir.Delete(true);
            }
            if (File.Exists(outputdata)) { File.Delete(outputdata); }

            encryptie.DecryptFile(SecuredData, DecryptedData);
        }




    }
}


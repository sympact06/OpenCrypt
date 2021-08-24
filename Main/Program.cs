using System;
using System.Security.Cryptography;
using System.IO;
using Encryption;
using System.IO.Compression;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Net;
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
            string cryptfolder = @".\OpenCrypt";
            string datafolder1 = @".\Data\Secured.zip";
            string outputdata = @".\OpenCrypt\temp\Encryptdit.zip";
            string olddata = @".\DataZip\OLD.zip";
            string SecuredData = @".\Secured\Data.txt";
            string DecryptedData = @".\Decrypt\Data.zip";
            System.IO.DirectoryInfo datafol = new DirectoryInfo(@".\Data");
            bool backup = false;
            void BackupMaak()
            {
                if (File.Exists(@".\OpenCrypt\temp\Encryptdit.zip"))
                {
                    string oldname = RandomString(20) + "-OLD.zip";
                    Console.WriteLine("Er is een oude zip gevonden! Hij word renamed naar " + oldname);
                    File.Move(@".\OpenCrypt\temp\Encryptdit.zip", @".\OpenCrypt\backups\" + oldname);
                    File.Delete(@".\OpenCrypt\temp\Encryptdit.zip");

                    string[] files = Directory.GetFiles(@".\OpenCrypt\backups\");
                    foreach (string file in files)
                    {

                        FileInfo fi = new FileInfo(file);
                        if (fi.LastAccessTime < DateTime.Now.AddDays(-10))
                            Console.WriteLine("Er zijn backups gevonden die ouder zijn dan 10 Dagen. Deze worden automatisch verwijderd om data te besparen!");
                            fi.Delete();
                    }
                    backup = true;
                }
            }

            void BackupMaak2()
            {
                if (backup == true)
                {
                    if (File.Exists(@".\OpenCrypt\temp\Encryptdit.zip"))
                    {

                        string oldname = RandomString(20) + "-AUTO.zip";
                        File.Copy(@".\OpenCrypt\temp\Encryptdit.zip", @".\OpenCrypt\backups\" + oldname);
                        backup = true;
                    }
                }
            }


            //STARTERS CONSOLELINES
            Console.WriteLine("OpenCrypt AES Encryptie Methode");
            Console.WriteLine("");

            //CHECK FOLDERS
            if (!Directory.Exists(datafolder)) { Console.WriteLine("Er was geen Data folder gevonden. Bevestig dat de folder echt Data heette.. Voor nu heb ik de Data folder aangemaakt"); Directory.CreateDirectory(@".\Data"); System.Environment.Exit(666); }
            if (!Directory.Exists(cryptfolder))
            {
                Console.WriteLine("Het lijkt erop dat dit de eerste keer is dat je OpenCrypt gebruikt We maken nu alle nodige files..");
                Directory.CreateDirectory(@".\OpenCrypt");
               
            }

            if (!Directory.Exists(@".\OpenCrypt\temp")) { Directory.CreateDirectory(@".\OpenCrypt\temp"); }
            if (!Directory.Exists(@".\OpenCrypt\backups")) { Directory.CreateDirectory(@".\OpenCrypt\backups"); }
            if (!Directory.Exists(@".\OpenCrypt\etc")) { Directory.CreateDirectory(@".\OpenCrypt\etc"); }
            if (!Directory.Exists(@".\OpenCrypt\credits")) { Directory.CreateDirectory(@".\OpenCrypt\credits"); }
            if (!Directory.Exists(@".\OpenCrypt\credits")){}
            if (!File.Exists(@".\OpenCrypt\credits\credits.txt"))
            {
                File.Create(@".\OpenCrypt\credits\credits.txt").Close();
                StreamWriter sw = new StreamWriter(@".\OpenCrypt\credits\credits.txt");
                sw.WriteLine("OPENCRYPT AES");
                sw.WriteLine("https://github.com/SympactDev/OpenCrypt");
                sw.WriteLine();
                sw.WriteLine();
                sw.WriteLine("Gemaakt door Tim... en Olivier...");
                sw.WriteLine("Dit is gemaakt voor onze USB Protectie! Maar wij hebben dit open-sourced. Dit is volledig Educational gemaakt en voor onze Opleiding!");
                sw.Close();
            }
            if (!File.Exists(@".\OpenCrypt\temp\lol.txt"))
            {
                File.Create(@".\OpenCrypt\temp\lol.txt").Close();
                StreamWriter sw = new StreamWriter(@".\OpenCrypt\temp\lol.txt");
                sw.WriteLine("Did you really thought we where stupid?");
                sw.WriteLine("Did you really thought we where stupid?");
                sw.WriteLine("Did you really thought we where stupid?");
                sw.WriteLine("Did you really thought we where stupid?");
                sw.WriteLine("Did you really thought we where stupid?");

                sw.Close();
            }
            if (!Directory.Exists(@".\OpenCrypt\dll"))
            {
                Directory.CreateDirectory(@".\OpenCrypt\dll");  
                using WebClient downloadclient = new WebClient();
                downloadclient.DownloadFile("https://cdn.discordapp.com/attachments/876164279382990909/879789837891289108/Encryption.dll", @".\OpenCrypt\dll\Encryption.dll");
                downloadclient.DownloadFile("https://cdn.discordapp.com/attachments/876164279382990909/879789837891289108/Encryption.dll", @".\OpenCrypt\dll\base.opencrypt");
                downloadclient.DownloadFile("https://cdn.discordapp.com/attachments/876164279382990909/879789837891289108/Encryption.dll", @".\OpenCrypt\dll\data.aes");
                downloadclient.DownloadFile("https://cdn.discordapp.com/attachments/876164279382990909/879789837891289108/Encryption.dll", @".\OpenCrypt\dll\data.opencrypt");
            }


            //Maak zip
            BackupMaak();
            ZipFile.CreateFromDirectory(@".\Data", @".\OpenCrypt\temp\Encryptdit.zip");
            BackupMaak2();
            yeboi.FileEncrypt(@".\OpenCrypt\temp\Encryptdit.zip", "wachtwoorxlol");
            Console.WriteLine("encrypted");
            File.Delete(@".\OpenCrypt\temp\Encryptdit.zip");
            foreach (FileInfo file in datafol.GetFiles()) { file.Delete(); }
            foreach (DirectoryInfo dir in datafol.GetDirectories()) { dir.Delete(true); }
            System.Environment.Exit(666);


        }




        }
    }


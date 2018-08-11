using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptAndDecrypt;
using System.IO;

namespace EaDTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select what you would like to do:\n1: Encrypt Text File\n2: Decrypt Text\n");
            string UserChoice = Console.ReadLine();
            if(UserChoice == "1")
            {
                if (args.Length > 0)
                {
                    string FilePath = args[0];

                    if (File.Exists(FilePath))
                    {
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            string FileContent = sr.ReadToEnd();
                            EncryptFileContent(FileContent, FilePath);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Filepath not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter the filepath of the text file: ");
                    string FilePath = Console.ReadLine();
                    if (FilePath.Length > 0)
                    {
                        if (File.Exists(FilePath))
                        {
                            using (StreamReader sr = new StreamReader(FilePath + "Encrypted.txt"))
                            {
                                string FileContent = sr.ReadToEnd();
                                EncryptFileContent(FileContent, FilePath);
                            }
                        }
                        else
                        {
                            Console.WriteLine("File Not Found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No FilePath Entered.");
                    }
                }
            } else
            {

            }
            ExitProgram();
        }

        static void EncryptFileContent(string FileContent, string FilePath)
        {
            if(FileContent.Length > 0)
            {
                string EncryptedText = EncryptAndDecrypt.EncryptDecrypt.Encrypt(FileContent);

                using(StreamWriter sw = new StreamWriter(FilePath))
                {
                    sw.WriteLine(EncryptedText);
                    Console.WriteLine("Encrypted text added to FilePath");
                }
            } else
            {
                Console.WriteLine("No File Content");
            }
        }

        static void DecryptFileContent(string FileContent, string FilePath)
        {

        }

        static void ExitProgram()
        {
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}

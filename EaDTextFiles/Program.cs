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
            Console.WriteLine("Please select what you would like to do:\n1: Encrypt Text File\n2: Decrypt Text File\n");
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
                            using (StreamReader sr = new StreamReader(FilePath))
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
            } else if(UserChoice == "2")
            {
                if (args.Length > 0)
                {
                    string FilePath = args[0];

                    if(File.Exists(FilePath)) 
                    {
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            string FileContent = sr.ReadToEnd();
                            DecryptFileContent(FileContent, FilePath);
                        }
                    }
                } else
                {
                    Console.WriteLine("Please enter the filepath of the text file: ");
                    string FilePath = Console.ReadLine();
                    if (FilePath.Length > 0)
                    {
                        if (File.Exists(FilePath))
                        {
                            using (StreamReader sr = new StreamReader(FilePath))
                            {
                                string FileContent = sr.ReadToEnd();
                                DecryptFileContent(FileContent, FilePath);
                            }
                        } else
                        {
                            Console.WriteLine("File Not Found.");
                        }
                    } else 
                    {
                        Console.WriteLine("No FilePath Entered.");
                    }
                }
            } else {
                Console.WriteLine("That's is not a valid user choice.");
            }
            ExitProgram();
        }

        static void EncryptFileContent(string FileContent, string FilePath)
        {
            if(FileContent.Length > 0)
            {
                string EncryptedText = EncryptAndDecrypt.EncryptDecrypt.Encrypt(FileContent);

                using(StreamWriter sw = new StreamWriter(FilePath + "-Encrypted.txt"))
                {
                    sw.WriteLine(EncryptedText);
                    Console.WriteLine("Encrypted text written to: {0}-Encrypted.txt", FilePath);
                }
            } else
            {
                Console.WriteLine("No File Content");
            }
        }

        static void DecryptFileContent(string FileContent, string FilePath)
        {
            if(FileContent.Length > 0)
            {
                string DecryptedText = EncryptAndDecrypt.EncryptDecrypt.Decrypt(FileContent);
                string FilePathDecrypted = FilePath.Remove(FilePath.Length-14);
                string NewFilePath = string.Format("{0}-Decrypted.txt", FilePathDecrypted);

                Console.WriteLine("New Path: {0}",NewFilePath);

                using(StreamWriter sw = new StreamWriter(NewFilePath)) 
                {
                    sw.WriteLine(DecryptedText);
                    Console.WriteLine("Decrypted text written to: {0}-Decrypted.txt", NewFilePath);
                }
            } else 
            {
                Console.WriteLine("No File Content");
            }
        }

        static void ExitProgram()
        {
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}

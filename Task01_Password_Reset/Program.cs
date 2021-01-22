using System;
using System.Text;

namespace Task01_Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawPassword = Console.ReadLine();

            while (true)
            {
                string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if(comand[0].ToUpper() == "DONE")
                {
                    break;
                }

                string typeComand = comand[0].ToUpper();

                switch (typeComand)
                {
                    case "TAKEODD":
                        string tempHelpPassword = string.Empty;
                        for (int i = 1; i < rawPassword.Length; i++)
                        {
                            if(i % 2 != 0)
                            {
                                tempHelpPassword += rawPassword[i];
                            }
                        }

                        rawPassword = tempHelpPassword;

                        Console.WriteLine(rawPassword);

                        break;

                    case "CUT":
                        int startIndex = int.Parse(comand[1]);
                        int lenght = int.Parse(comand[2]);

                        rawPassword = rawPassword.Remove(startIndex, lenght);

                        Console.WriteLine(rawPassword);

                        break;

                    case "SUBSTITUTE":
                        string cutSubstring = comand[1];
                        string pasteSubstring = comand[2];

                        if(rawPassword.Contains(cutSubstring))
                        {
                            rawPassword = rawPassword.Replace(cutSubstring, pasteSubstring);
                            Console.WriteLine(rawPassword);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }

                        break;
                    
                    default:
                        break;
                }

            }
                       
            Console.WriteLine($"Your password is: {rawPassword}");
        }
    }
}

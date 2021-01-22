using System;
using System.Text.RegularExpressions;

namespace Task02_Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {

            string patern = @"(@#+)([A-Z][\d|[a-zA-Z)]{4,}[A-Z])(@#+)";   // @"(@#+)([A-Z][\d|[A-z)]{4,}[A-Z])(@#+)";   //@"(@#+)([A-Z][[[:alnum:]]{4,}[A-Z])(@#+)";
            Regex validBarCode = new Regex(patern);


            int productsNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= productsNumber; i++)
            {
                string productGroup = string.Empty;
                string nextProduct = Console.ReadLine();

                MatchCollection productBarCode = validBarCode.Matches(nextProduct);

                if (productBarCode.Count > 0)
                {
                    string helpName = productBarCode[0].ToString();

                    //string helpName = productBarCode.ToString();

                    string digitPatern = @"\d";
                    Regex extractDigits = new Regex(digitPatern);

                    MatchCollection digits = extractDigits.Matches(helpName);

                    foreach (Match digit in digits)
                    {
                        productGroup += digit;
                    }

                    if(productGroup.Length < 1)
                    {
                        productGroup = "00";
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                    //break;
                }
            }
        }
    }
}

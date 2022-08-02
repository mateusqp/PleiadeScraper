using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PleiadeScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Xpath: /html/body/div[1]/div/div[2]/div/div[2]/div[3]/ul[2]/li[i]  // (for int i = 0; blablabla)
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();

            char letter = 'A'; ;
            int dec;
            List<string> letterUrls = new List<string>();

            do
            {
                HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.la-pleiade.fr/Le-catalogue/Par-auteur/(letter)/" + letter);
                
                do
                {
                    foreach (var item in doc.DocumentNode.SelectNodes("/html/body/div[1]/div/div[2]/div/div[2]/div[3]/ul[2]/li/a"))
                    {
                        if(item.Attributes[0] != null)
                        letterUrls.Add(item.Attributes[0].Value.Trim());                        
                    }
                    
                } while (false);

                letter++;
                dec = letter;
                
            } while (dec < 90 + 1); // Z = 90;





            foreach (string s in letterUrls)
            {
                Console.WriteLine(s);
                do
                {
                    HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.la-pleiade.fr/Le-catalogue/Par-auteur/(letter)/" + letter);

                    do
                    {
                        foreach (var item in doc.DocumentNode.SelectNodes("/html/body/div[1]/div/div[2]/div/div[2]/div[3]/ul[2]/li/a"))
                        {
                            if (item.Attributes[0] != null)
                                letterUrls.Add(item.Attributes[0].Value.Trim());
                        }

                    } while (false);

                    letter++;
                    dec = letter;

                } while (dec < 90 + 1); // Z = 90;
            }
            Console.ReadLine();
        }
    }
}

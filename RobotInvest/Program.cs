using System;
using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace RobotInvest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = startCrawlerAsync();
            Console.ReadKey();
        }

        public static async Task startCrawlerAsync()
        {
            var url = "https://www.infomoney.com.br/cotacoes/b3/acao/petrobras-petr4/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var investments = new List<Investiment>();

            var divValor = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("div", "").Equals("value")).ToList();

            foreach(var div in divValor)
            {
                var valor = new Investiment()
                {
                    Quantidade = 5,
                    PrecoCompra = 29.25M,
                    PrecoMercado = div.Descendants("p").FirstOrDefault().InnerText.Replace(",","."),
                };
                investments.Add(valor);
            }


        }

    }
}

using System;

namespace testteze
{
    class Program
    {
        static void Main(string[] args)
        {
            var compra = 73;
            if (compra >= 120)
            {
                compra = compra - ((compra * 30) / 100);

            }else if (compra >= 100 && compra <= 119)
            {
                compra = compra - ((compra * 20) / 100);
            }
            else if (compra >= 50 && compra <= 99)
            {
                compra = compra - ((compra * 10) / 100);
            }

           
 



            Console.WriteLine(compra);

            Console.ReadKey();
        }

       
    }
}


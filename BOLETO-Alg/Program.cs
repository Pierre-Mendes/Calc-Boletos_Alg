using System;

namespace BOLETO_Alg
{
    class Program
    {
        static void Main(string[] args)
        {
         string bar_code = "";
         string  bank, day, month, year, complete_date;
         decimal value = 0;
         DateTime expiration_date = DateTime.Now, date_new;
         bool up = false;
         
        date_new = DateTime.Now;

        Console.WriteLine(" *** A Data de Hoje é: {0} ***", date_new);

        Console.Write(" *** Insira o Código de barras: *** ");
        bar_code = Console.ReadLine();

        Console.Clear();

         do
            {
                try
                {
                    up = true;
                    Console.Write(" *** Insira uma data: *** ");
                    expiration_date = DateTime.Parse(Console.ReadLine());
                }
                 catch
                {
                    Console.WriteLine(" A Data inserida é inválida...! - pressione qualquer tecla...");
                    up = false;
                }

                Console.Clear();
            }
            while (!up);

            Console.WriteLine(" Data inserida: {0}", expiration_date);

            bank = bar_code.Substring(0, 3);
            day = bar_code.Substring(3, 2);
            month = bar_code.Substring(5, 2);
            year = bar_code.Substring(7, 4);

            value = decimal.Parse(bar_code.Substring(11)) / 100m;

            if (bank == " 001 ")
            {
                Console.WriteLine(" *** Banco do Brasil ***");
            }
            else if (bank == " 237 ")
            {
                Console.WriteLine(" **** Banco Bradesco *** ");
            }
            else if (bank == " 341 ")
            {
                Console.WriteLine(" *** Banco Itaú *** ");
            }
            else
            {
                Console.WriteLine(" *** Banco Desconhecido/Outros ***");
            }

            complete_date = day + "/" + month + "/" + year;

            Console.WriteLine(" *Banco: {0} ", bank);

            Console.WriteLine(" *Data de Vencimento: {0} ", complete_date);

            Console.WriteLine(" *Valor do boleto a ser pago: {0:C}", value);

            if (date_new < DateTime.Parse(complete_date))
            {
                Console.WriteLine(" *Valor a pagar {0:C}", value);
            }
            else
            {
                Console.WriteLine(" *Valor a pagar {0:C}", value * 1.2m);
            }


        }
    }
}

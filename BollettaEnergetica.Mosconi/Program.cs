using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BollettaEnergetica bolletta = new BollettaEnergetica("000aaa", 0.25, 0.10, 50, 10);
            BollettaEnergetica bollettina = new BollettaEnergetica("001aab", 0.25, 0.15, 50, 10);

            string code = bolletta.CodiceGenerale();
            bolletta.Modifica(code, 0.24, 0.11, 50, 10);
            Console.WriteLine(bolletta.ToString());

            Console.WriteLine(bolletta.PrezzoTot());

            Console.WriteLine(bolletta.Confronto(bollettina));

            bolletta.IncrementaUnitaDistribuzione(5);
            Console.WriteLine(bolletta.ToString());

            string cod1 = bolletta.CodiceGenerale();
            string cod2 = bollettina.CodiceGenerale();

            Console.WriteLine($"cod1: {cod1} - cod2: {cod2}");
        }
    }
}

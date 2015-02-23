using System;

namespace OE.Prog2.Jatek.Jatekter
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. óra tesztelése:
            /*JatekTer ter = new JatekTer(5, 10);
            JatekElem elem1 = new JatekElem(1, 2, ref ter);
            JatekElem elem2 = new JatekElem(1, 5, ref ter);
            JatekElem elem3 = new JatekElem(6, 2, ref ter);
            JatekElem elem4 = new JatekElem(2, 2, ref ter);

            ter.Torol(elem3);
            Console.WriteLine(ter.MegadottHelyenLevok(2, 2).Length+"db található a megadott helyen");

            JatekElem[] tomb = ter.MegadottHelyenLevok(1, 1, 5);
            Console.WriteLine("Megadott pont környezetében:");
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.WriteLine(tomb[i].X + "-" + tomb[i].Y);
            }
             
             Console.ReadKey();
             */

            //2. óra tesztelése:
            OE.Prog2.Jatek.Keret.Keret keret = new Keret.Keret();
            keret.Futtatas();            
        }
    }
}

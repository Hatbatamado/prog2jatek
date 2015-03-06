using System;
using OE.Prog2.Jatek.Szabalyok;
using OE.Prog2.Jatek.Jatekter;
using OE.Prog2.Jatek.Automatizmus;

namespace OE.Prog2.Jatek.Szabalyok
{
    class GepiJatekos : Jatekos, IAutomatikusanMukodo
    {
        private static Random R = new Random();

        //Paraméterei ugyanazok mint az ős konstruktorának, csak hozzá továbbítsa a kapott adatokat
        public GepiJatekos(string nev, int x, int y, ref JatekTer ter)
            : base(nev, x, y, ref ter)
        {
        }

        //Generáljunk egy véletlen számot 0 és 3 között. Majd ennek értékétől függően
        //az objektum próbáljon meg elmozdulni fel-jobbra-le-balra irányok közül valamerre
        public void Mozgas()
        {
            int veletlen = R.Next(4);
            int[] veletlenszamok = new int[] { 0, 1, 2, 3 };
            int[] seged;
            int db = 0;
            int i = 0;

            while (veletlenszamok.Length > 0)
            {
                try
                {
                    HovaMegy(veletlen);
                }
                catch (MozgasHelyHianyMiattNemSikerultKivetel)
                {
                    //TODO tömb-ből törölje ahova nem tud menni  
						  //DEBUG: miért ugrál össze-vissza törlésre
                }
            }

            //TODO esemény-re reag.
           /* //Amennyiben a Megy metódus hívásakor egy MozgasHelyHianyMiattNemSikerult kivételt kapnánk,
            //akkor automatikusan próbálkozzon a következő irányba lépni*/
        }

        private void HovaMegy(int veletlen)
        {
            switch (veletlen)
            {
                case 0: //fel
                    Megy(0, -1);
                    break;
                case 1: //jobbra
                    Megy(1, 0);
                    break;
                case 2: //lefele
                    Megy(0, 1);
                    break;
                case 3: //balra
                    Megy(-1, 0);
                    break;
            }
        }

        //Visszatérési értéke legyen '\u2640'
        public override char Alak
        {
            get
            {
                return '\u2640';
            }
        }

        //hívja meg a már létező Mozgas metódust
        public void Mukodik()
        {
            Mozgas();
        }

        //mindig adjon vissza 2-t (tehát 2 tizedmásodpercenként szeretnénk léptetni az ellenfelet)
        public int MukodesIntervallum
        {
            get
            {
                return 2;
            }
        }
    }
}

using System;
using OE.Prog2.Jatek.Jatekter;
using OE.Prog2.Jatek.Megjelenites;

namespace OE.Prog2.Jatek.Szabalyok
{
    class Jatekos : MozgoJatekElem, IKirajzolhato, IMegjelenitheto
    {
        private string nev; //tárolja a játékos nevét

        public string Nev
        {
            get { return nev; }
        }

        private int eletero = 100; //kezdőértéke 100. Tárolja a játékos életerejét
        private int pontszam = 0; //kezdőértéke 0. Tárolja, hogy a játékos eddig hány pontot szerzett a játékban

        //négy paramétere van: név, x, y, játéktér. Az elsőt eltárolja a megfelelő mezőben, a többit továbbítja az ős konstruktorának
        public Jatekos(string nev, int x, int y, ref JatekTer ter)
            : base(x, y, ref ter)
        {
            this.nev = nev;
        }

        //adjon vissza 0.2-t (tehát 5 játékos fér el egy mezőn, ha nincs ott más
        public override double Meret
        {
            get
            {
                return 0.2;
            }
        }

        //ne csináljon semmit
        public override void Utkozes(JatekElem jatekelem)
        {
        }

        public void Serul(int sebzes)
        {
            //Ha a játékos életereje már eleve 0, akkor ne csináljon semmit
            if (eletero == 0) return;

            //Ha nagyobb, akkor csökkentse az eletero-t a paraméterként átadott értékkel (de 0-nál kisebb ne legyen)
            eletero -= sebzes;
            if (eletero < 0)
                eletero = 0;

            //Ha a játékos életereje elérte a 0-t, akkor az Aktiv tulajdonságot állítsa hamisra
            if (eletero == 0)
                Aktiv = false;
        }

        //A megadott paraméterrel növeli a pontszam mező értékét.
        public void PontotSzerez(int pluszpont)
        {
            pontszam += pluszpont;
        }

        //két paramétere két relatív koordináta (rx és ry, tipikusan -1, 0, 1 értékeket várunk ezekben).
        //Számolja ki, hogy az aktuális pozícióból ezzel az elmozdulással hova jutna,
        //és hívja meg az ősétől örökölt Athelyez függvényt ezekkel a koordinátákkal.
        public void Megy(int rx, int ry)
        {
            this.AtHelyez(this.X + rx, this.Y + ry);
            //Console.WriteLine(nev + ": " + X + "," + Y);
        }

        //csak olvasható, visszatérési értéke legyen attól függően, hogy ha még aktív, akkor '\u263A', különben '\u263B'
        public char Alak
        {
            get
            {
                if (Aktiv)
                    return '\u263A';
                else
                    return '\u263B';
            }
        }

        //mivel a játékosnak van egy referenciája ahhoz a JatekTer-hez, amelyikben van, így adja vissza annak a méreteit
        public int[,] MegjelenitendoMeret
        {
            get
            {
                return new int[ter.MeretX, ter.MeretY];
            }
        }

        //a játékos a pálya 5 sugarú környezetét látja be, így az itt található elemeket fogja visszaadni
        public IKirajzolhato[] MegjelenitendoElemek()
        {
            //Kérje le a játéktértől az ő 5 sugarú környezetében található elemek tömbjét
            JatekElem[] belathtoElemek = ter.MegadottHelyenLevok(X, Y, 5);

            //Ebben számolja meg, hogy hány olyan objektum van, ami megvalósítja az IKirajzolhato interfészt
            int db = 0;
            for (int i = 0; i < belathtoElemek.Length; i++)
            {
                if (belathtoElemek[i] is IKirajzolhato)
                    db++;
            }

            //Hozzon létre egy ekkora, IKirajzolhato nevű tömböt vissza néven
            IKirajzolhato[] vissza = new IKirajzolhato[db];

            //Ebbe a tömbbe válogassa ki az interfészt megvalósító elemeket
            db = 0;
            for (int i = 0; i < belathtoElemek.Length; i++)
            {
                if (belathtoElemek[i] is IKirajzolhato)
                    vissza[db++] = belathtoElemek[i] as IKirajzolhato;
            }

            return vissza;
        }
    }
}

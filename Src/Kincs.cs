using System;
using OE.Prog2.Jatek.Jatekter;
using OE.Prog2.Jatek.Megjelenites;

namespace OE.Prog2.Jatek.Szabalyok
{
    //két paraméterrel rendelkezzen:
    //A Kincs referenciája amit felvettek. A Jatekos referenciája, aki felvette.
    delegate void KincsFelvetelKezelo(ref Kincs kincs, ref Jatekos jatekos);

    //három paraméterrel rendelkezzen:
    //Az eseményt küldő Jatekos referenciája. A játékos új pontszáma. A játékos új életereje.
    delegate void JatekosValtozasKezelo(ref Jatekos jatekos, int ujpontszam, int ujeletero);

    class Kincs : RogzitettJatekElem, IKirajzolhato
    {
        //az őséhez hasonlóan x és y és játéktér paramétereket kap, ezeket továbbítja az ősnek
        public Kincs(int x, int y, ref JatekTer ter)
            : base(x, y, ref ter)
        {
            //Console.WriteLine(x + "," + y); //2. órai teszteléshez
        }

        //Mindig adjon vissza 1-et
        public override double Meret
        {
            get
            {
                return 1;
            }
        }
        
        public override void Utkozes(JatekElem jatekelem)
        {
            //Ellenőrizzük, hogy a nekiütköző (tehát a paraméterként kapott JatekElem) egy Jatekos típusú objektum-e
            if (jatekelem is Jatekos)
            {
                Jatekos jatekos = (Jatekos)jatekelem;
                //Ha igen, akkor hívjuk meg annak PontSzerez metódusát, paraméterként 50-et átadva
                jatekos.PontotSzerez(50);
                //Console.WriteLine(jatekos.Nev); //2. órai teszteléshez

                //A kincs törölje önmagát a játéktérről
                ter.Torol(this);
                
                //amennyiben egy játékos felvette a kincset, és valaki feliratkozott a fenti eseménykezelőre,
                //akkor küldjön az eseményről egy értesítést
                if (KincsFelvetel != null)
                {
                    Kincs kincs = this;
                    KincsFelvetel(ref kincs, ref jatekos);
                }
            }
        }

        public char Alak //csak olvasható, visszatérési értéke '\u2666'
        {
            get
            {
                return '\u2666';
            }
        }

        //legyen egy KincsFelvetelKezelo típusú eseménykezelő
        public event KincsFelvetelKezelo KincsFelvetel; 
    }
}

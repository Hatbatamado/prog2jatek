using System;
using OE.Prog2.Jatek.Szabalyok;

namespace OE.Prog2.Jatek.Megjelenites
{
    class KonzolosEredmenyAblak
    {
        private int pozX; //ennyivel kell majd eltolni a kirajzolandó adatok x koordinátáját
        private int pozY; //ennyivel kell majd eltolni a kirajzolandó adatok y koordinátáját
        private int maxSorSzam; //hány sor fér ki az eredményablakba
        private int sor = 0; //aktuális sorok száma (alapból 0)

        public KonzolosEredmenyAblak(int pozX, int pozY, int maxSorSzam)
        {
            this.pozX = pozX;
            this.pozY = pozY;
            this.maxSorSzam = maxSorSzam;
        }

        //A JatekosValtozasKezelo delegáltnak megfelelő paraméterekkel rendelkezzen
        private void JatekosValtozasTortent(ref Jatekos jatekos, int ujpontszam, int ujeletero)
        {
            //A SzalbiztosKonzol segítségével írja ki a pozX és pozY által megadott helyre,
            //az aktuális sornak megfelelő sorba az alábbi adatokat „játékos neve:…, pontszáma:…, életereje:…”.
            SzalbiztosKonzol.KiirasXY(pozX, pozY + sor, "játékos neve: " + jatekos.Nev +
                ", pontszáma: " + ujpontszam + ", életereje: " + ujeletero + "   ");

            //növelje a sor értékét. Ha ez nagyobb mint a maxSorSzam, akkor állítsa 0-ra
            if (++sor >= maxSorSzam)
                sor = 0;
        }

        //paraméterként egy Jatekos objektumot kap
        public void JatekosFeliratkozas(Jatekos jatekos)
        {
            //Az objektum JatekosValtozas eseményére iratkozzon fel az előző metódussal
            jatekos.JatekosValtozas += JatekosValtozasTortent;
        }
    }
}

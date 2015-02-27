using System;
using OE.Prog2.Jatek.Automatizmus;

namespace OE.Prog2.Jatek.Megjelenites
{
    class KonzolosMegjelenito : IAutomatikusanMukodo
    {
        private IMegjelenitheto forras;
        private int pozX; //ennyivel kell majd eltolni a kirajzolandó adatok x koordinátáját
        private int pozY; //ennyivel kell majd eltolni a kirajzolandó adatok y koordinátáját

        public KonzolosMegjelenito(IMegjelenitheto forras, int pozX, int pozY)
        {
            this.forras = forras;
            this.pozX = pozX;
            this.pozY = pozY;
        }

        public void Megjelenites()
        {
            //A forras objektum MegjelenitendoElemek metódusával kiolvassa a kirajzolandó elemek tömbjét
            IKirajzolhato[] kirajzElemek = forras.MegjelenitendoElemek();
            //Lekérdezi azt is, hogy mekkora a megjelenítendő terület mérete
            int[] meret = forras.MegjelenitendoMeret;
            int db;

            //Ezt követően két egymásba ágyazott ciklussal végigszaladunk a méret által megadott területen
            for (int i = 0; i <= meret[0]; i++)
            {
                for (int j = 0; j <= meret[1]; j++)
                {
                    db = 0;
                    while (db < kirajzElemek.Length && !(i == kirajzElemek[db].X && j == kirajzElemek[db].Y))
                        db++;

                    if (db < kirajzElemek.Length)
                        //ha megadott ponton van valami, akkor pedig annak az Alak tulajdonsága által
                        //visszaadott karaktert írjuk ki a megadott helyre
                        SzalbiztosKonzol.KiirasXY(i + pozX, j + pozY, kirajzElemek[db].Alak);
                    else
                        //ha a forrás által visszaadott objektumok egyike sincs a megadott ponton,
                        //akkor kiírunk oda egy szóközt a SzalbiztosKonzol segítségével
                        SzalbiztosKonzol.KiirasXY(i + pozX, j + pozY, ' ');
                }
            }
        }

        //hívja meg a már létező Megjelenites metódust
        public void Mukodik()
        {
            Megjelenites();
        }

        //mindig adjon vissza 1-t (tehát minden órajel-ciklusban frissíteni kell a képernyőt)
        public int MukodesIntervallum
        {
            get
            {
                return 1;
            }
        }
    }
}

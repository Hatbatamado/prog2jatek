using System;

namespace OE.Prog2.Jatek.Jatekter
{
    class JatekTer
    {
        const int MAX_ELEMSZAM = 1000; //a tárolható elemek maximális száma (1000)
        private int elemN = 0; //azt mutatja, hogy éppen hány elemet tárolunk.
        private JatekElem[] elemek = new JatekElem[MAX_ELEMSZAM]; //MAX_ELEMSZAM méretű, JatekElem objektumokat tartalmazó tömb.
        private int meretX; //a játéktér maximális mérete x irányban

        public int MeretX
        {
            get { return meretX; }
        }

        private int meretY; //a játéktér maximális mérete y irányban

        public int MeretY
        {
            get { return meretY; }
        }

        //két paramétere legyen, amelyek beállítják a meretX és meretY mezők értékét
        public JatekTer(int meretX, int meretY) 
        {
            this.meretX = meretX;
            this.meretY = meretY;
        }

        //felveszi a paraméterként átadott JatekElem típusú objektumot az elemek tömbbe
        public void Felvetel(JatekElem jatekelem)
        {
            elemek[elemN++] = jatekelem;
        }

        //törli a paraméterként átadott JatekElem objektumot az elemek tömbből
        public void Torol(JatekElem jatekelem)
        {
            int i = 0;
            while (i < elemN && elemek[i] != jatekelem)
                i++;
            if (i < elemN)
            {
                for (int k = i; k < elemN - 1; k++)
                {
                    elemek[k] = elemek[k + 1];
                }
            }
            elemN--;
        }

        //három paramétere van: egy x és y koordináta, illetve egy távolság, a visszatérési értéke pedig egy JatekElem objektumokat tartalmazó tömb
        //az x és y koordináták által meghatározott ponttól mért távolság távolságon belül hány darab JatekElem objektum található
        //Létre kell hoznia egy ekkora JatekElem tömböt, majd ebbe ki kell válogatnia az előző feltételnek megfelelő elemeket.
        //Ez lesz a metódus visszatérési értéke.
        public JatekElem[] MegadottHelyenLevok(int x, int y, int tavolsag)
        {
            int db = 0;
            JatekElem[] seged = new JatekElem[elemN];
            for (int i = 0; i < elemN; i++)
            {
                if (Math.Sqrt(Math.Pow(elemek[i].X - x, 2) +
                    (Math.Pow(elemek[i].Y - y, 2))) <= tavolsag)
                {
                    seged[db++] = elemek[i];
                }
            }

            JatekElem[] megadott = new JatekElem[db];
            for (int i = 0; i < db; i++)
                megadott[i] = seged[i];

            return megadott;
        }

        //csak x és y paramétere van
        //Visszatérési értéke egy JatekElem tömb, ami azokat az elemeket tartalmazza, amelyek pont az x és y által megadott helyen vannak
        public JatekElem[] MegadottHelyenLevok(int x, int y)
        {
            return MegadottHelyenLevok(x, y, 0);
        }

    }
}
using System;

namespace OE.Prog2.Jatek.Jatekter
{
    class JatekTer
    {
        const int MAX_ELEMSZAM = 1000;
        private int elemN = 0;
        private JatekElem[] elemek = new JatekElem[MAX_ELEMSZAM];
        private int meretX;

        public int MeretX
        {
            get { return meretX; }
        }

        private int meretY;

        public int MeretY
        {
            get { return meretY; }
        }

        public JatekTer(int meretX, int meretY)
        {
            this.meretX = meretX;
            this.meretY = meretY;
        }

        public void Felvetel(JatekElem jatekelem)
        {
            elemek[elemN++] = jatekelem;
        }

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

        public JatekElem[] MegadottHelyenLevok(int x, int y)
        {
            int db = 0;
            JatekElem[] seged = new JatekElem[elemN];
            for (int i = 0; i < elemN; i++)
            {
                if (Math.Sqrt(Math.Pow(elemek[i].X - x, 2) +
                    (Math.Pow(elemek[i].Y - y, 2))) == 0)
                {
                    seged[db++] = elemek[i];
                }
            }

            JatekElem[] megadott = new JatekElem[db];
            for (int i = 0; i < db; i++)
                megadott[i] = seged[i];

            return megadott;
        }

    }
}
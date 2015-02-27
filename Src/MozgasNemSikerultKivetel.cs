using System;
using OE.Prog2.Jatek.Jatekter;
using OE.Prog2.Jatek.Automatizmus;

namespace OE.Prog2.Jatek.Szabalyok
{
    class MozgasNemSikerultKivetel : Exception
    {
        private JatekElem jatekElem; //ez tárolja, hogy ki nem tudott lépni

        internal JatekElem JatekElem
        {
            get { return jatekElem; }
            //set { jatekElem = value; } //ha minden igaz, akkor nem kell
        }

        private int x; //ez tárolja, hogy hova szerett volna lépni (x koordináta)

        public int X
        {
            get { return x; }
            //set { x = value; } //ha minden igaz, akkor nem kell
        }

        private int y; //ez tárolja, hogy hova szerett volna lépni (y koordináta)

        public int Y
        {
            get { return y; }
            //set { y = value; } //ha minden igaz, akkor nem kell
        }

        public MozgasNemSikerultKivetel(JatekElem jatekElem, int x, int y)
        {
            this.jatekElem = jatekElem;
            this.x = x;
            this.y = y;
        }
    }
}

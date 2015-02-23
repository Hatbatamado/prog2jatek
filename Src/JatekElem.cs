using System;

namespace OE.Prog2.Jatek.Jatekter
{
    abstract class JatekElem
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public abstract double Meret
        {
            get;
        }

        protected JatekTer ter;

        public JatekElem(int x, int y, ref JatekTer ter)
        {
            this.x = x;
            this.y = y;
            this.ter = ter;

            ter.Felvetel(this);
        }

        public abstract void Utkozes(JatekElem jatekelem);
    }
}
using System;

namespace OE.Prog2.Jatek.Jatekter
{
    abstract class JatekElem
    {
        private int x; //az elem pozíciójának x koordinátája

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y; //az elem pozíciójának y koordinátája

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public abstract double Meret //0..1 közötti értéke lehet majd, egy mezőbe elhelyezkedő elemek mérete nem lehet 1-nél több
        {
            get;
        }

        protected JatekTer ter; //árolja annak a JatekTer típusú játéktérnek a referenciáját, amelyikbe elhelyeztük

        //paraméterként megkapja az x és y koordinátákat, illetve egy JatekTer referenciát.
        //Mindhárom paramétert mentse el az ezekre szolgáló mezőkbe, majd vegye fel magát a JatekTer objektum Felvetel metódusával
        public JatekElem(int x, int y, ref JatekTer ter)
        {
            this.x = x;
            this.y = y;
            this.ter = ter;

            ter.Felvetel(this);
        }

        //ez fogja majd kezelni a különböző típusú elemek ütközéseit
        public abstract void Utkozes(JatekElem jatekelem);
    }
}
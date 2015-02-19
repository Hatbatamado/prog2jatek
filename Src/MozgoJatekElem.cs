using System;

namespace OE.Prog2.Jatek.Jatekter
{
    class MozgoJatekElem : JatekElem
    {
        private bool aktiv;

        public bool Aktiv
        {
            get { return aktiv; }
            set { aktiv = value; }
        }

        public MozgoJatekElem(int x, int y, ref JatekTer ter) : base(x,y,ref ter)
        {

        }

        protected void AtHelyez(int ujx, int ujy)
        {

        }
    }
}

using System;

namespace OE.Prog2.Jatek.Jatekter
{
    abstract class MozgoJatekElem : JatekElem
    {
        private bool aktiv;

        public bool Aktiv
        {
            get { return aktiv; }
            set { aktiv = value; }
        }

        public MozgoJatekElem(int x, int y, ref JatekTer ter)
            : base(x, y, ref ter)
        {

        }

        protected void AtHelyez(int ujx, int ujy)
        {
            JatekElem[] maselemek = ter.MegadottHelyenLevok(ujx, ujy);
            double meret = 0;

            for (int i = 0; i < maselemek.Length; i++)
            {
                maselemek[i].Utkozes(this);
                if (!Aktiv)
                    break;
                else
                    maselemek = ter.MegadottHelyenLevok(ujx, ujy);
            }

            for (int i = 0; i < maselemek.Length; i++)
            {
                this.Utkozes(maselemek[i]);
                if (!Aktiv)
                    break;
                else
                    maselemek = ter.MegadottHelyenLevok(ujx, ujy);
            }

            for (int i = 0; i < maselemek.Length; i++)
                meret += maselemek[i].Meret;

            if ((this.Meret + meret) <= 1)
            {
                this.X = ujx;
                this.Y = ujy;
            }


        }
    }
}

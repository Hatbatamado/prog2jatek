using System;
using OE.Prog2.Jatek.Jatekter;

namespace OE.Prog2.Jatek.Szabalyok
{
    class MozgasHelyHianyMiattNemSikerultKivetel : MozgasNemSikerultKivetel
    {
        JatekElem[] elemek; //azokat az elemeket fogja tároli, amelyek miatt nem sikerült a lépés
        internal JatekElem[] Elemek
        {
            get { return elemek; }
        }

        public MozgasHelyHianyMiattNemSikerultKivetel(JatekElem jatekElem, int x, int y, JatekElem[] elemek)
            : base(jatekElem, x, y)
        {
            this.elemek = elemek;
        }
    }
}

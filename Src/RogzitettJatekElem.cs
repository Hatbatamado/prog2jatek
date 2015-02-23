using System;

namespace OE.Prog2.Jatek.Jatekter
{
    abstract class RogzitettJatekElem : JatekElem
    {
        //paraméterként megkapja az x és y koordinátákat, illetve egy JatekTer referenciát.
        //Ezeket továbbítsa az ősének konstruktorához
        public RogzitettJatekElem(int x, int y, ref JatekTer ter)
            : base(x, y, ref ter)
        {

        }
    }
}

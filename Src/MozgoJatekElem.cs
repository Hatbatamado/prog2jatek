using System;
using OE.Prog2.Jatek.Szabalyok;

namespace OE.Prog2.Jatek.Jatekter
{
    abstract class MozgoJatekElem : JatekElem
    {
        private bool aktiv = true; //azt mutatja majd, hogy működik/él-e még az adott objektum

        public bool Aktiv
        {
            get { return aktiv; }
            set { aktiv = value; }
        }

        //paraméterként megkapja az x és y koordinátákat, illetve egy JatekTer referenciát.
        //Ezeket továbbítsa az ősének konstruktorához
        public MozgoJatekElem(int x, int y, ref JatekTer ter)
            : base(x, y, ref ter)
        {
        }

        protected void AtHelyez(int ujx, int ujy)
        {
            //kérdezze le, hogy az új koordináták által megadott helyen éppen milyen más játékelemek találhatók
            JatekElem[] maselemek = ter.MegadottHelyenLevok(ujx, ujy);
            double meret = 0;

            //az elemeknek egyesével hívja meg az Utkozes metódusát, paraméterként átadva önmagát
            //a mozgatandó objektum nekiütközik a cél helyen lévőknek
            for (int i = 0; i < maselemek.Length; i++)
            {
                maselemek[i].Utkozes(this);
                //Minden ütközés után ellenőrizze, hogy még Aktiv-e a mozgatandó objektum.
                //Ha már nem az, akkor ne folytassa az ütközéseket.
                if (!Aktiv)
                {
                    //Ha az ütközések hatására meghalt a mozgatni kívánt elem,
                    //akkor dobjunk egy MozgasHalalMiattNemSikerult kivételt a megfelelő paraméterekkel
                    new MozgasHalalMiattNemSikerultKivetel(this, this.X, this.Y);
                    break;
                }
            }
            
            if (Aktiv)
            {
                //Ha az ütközések után még Aktiv a mozgatandó objektum, akkor kérje le ismét a cél helyen található elemeket
                maselemek = ter.MegadottHelyenLevok(ujx, ujy);
                //Ha az ütközéseket túlélte, de a cél területen már meglévő objektumok mellé már nem fért el az elem,
                //akkor dobjon egy MozgasHelyHianyMiattNemSikerult kivételt a megfelelő paraméterekkel
                if (maselemek.Length > 0)
                    new MozgasHelyHianyMiattNemSikerultKivetel(this, ujx, ujy, maselemek);
            }

            //a cél helyen lévő ütközik neki a mozgatandó objektumnak
            for (int i = 0; i < maselemek.Length; i++)
            {
                this.Utkozes(maselemek[i]);
                //Minden ütközés után ellenőrizze, hogy még Aktiv-e a mozgatandó objektum.
                //Ha már nem az, akkor ne folytassa az ütközéseket.
                if (!Aktiv)
                {
                    new MozgasHalalMiattNemSikerultKivetel(this, ujx, ujy);
                    break;
                }

                //Ha az ütközések után még Aktiv a mozgatandó objektum, akkor kérje le ismét a cél helyen található elemeket
                if (Aktiv)
                    maselemek = ter.MegadottHelyenLevok(ujx, ujy);
            }

            //Számolja ki, hogy mennyi a cél helyen már meglévő elemek összesített mérete
            for (int i = 0; i < maselemek.Length; i++)
                meret += maselemek[i].Meret;

            //Ha ehhez még hozzáadjuk az odaléptetni kívánt elem méretét, akkor ez nem haladhatja meg az 1-et
            //Ha ez alapján elvégezhető a lépés, akkor az objektum x és y koordinátáit léptessük az új helyre.
            //Ha nem, akkor ne változtassuk meg.
            if ((this.Meret + meret) <= 1)
            {
                this.X = ujx;
                this.Y = ujy;
            }
        }
    }
}

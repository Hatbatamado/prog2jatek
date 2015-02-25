using System;
using OE.Prog2.Jatek.Jatekter;

namespace OE.Prog2.Jatek.Szabalyok
{
    class GonoszGepiJatekos : GepiJatekos
    {
        //Paraméterei ugyanazok mint az ős konstruktorának, csak hozzá továbbítsa a kapott adatokat.
        public GonoszGepiJatekos(string nev, int x, int y, ref JatekTer ter)
            : base(nev, x, y, ref ter)
        { }

        //Visszatérési értéke legyen '\u2642'
        public override char Alak
        {
            get
            {
                return '\u2642';
            }
        }

        //Hívja meg az ős Utkozes metódusát. Ha még ezek után Aktiv a játékos,
        //és a paraméterként átadott ütköző objektum egy Jatekos objektum (vagy annak leszármazottja),
        //akkor hívja meg annak Serul metódusát paraméterként 10-et adva át
        public override void Utkozes(JatekElem jatekos)
        {
            base.Utkozes(jatekos);
            if (Aktiv && (jatekos is Jatekos))
                (jatekos as Jatekos).Serul(10);
        }
    }
}

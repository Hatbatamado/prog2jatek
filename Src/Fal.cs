using System;
using OE.Prog2.Jatek.Jatekter;
using OE.Prog2.Jatek.Megjelenites;

namespace OE.Prog2.Jatek.Szabalyok
{
    class Fal : RogzitettJatekElem, IKirajzolhato
    {
        //az őséhez hasonlóan x és y és játéktér paramétereket kap, ezeket továbbítja az ősnek
        public Fal(int x, int y, ref JatekTer ter)
            : base(x, y, ref ter)
        { }

        //Mindig adjon vissza 1-et (tehát egy fal mellé más már biztos nem fog elférni
        public override double Meret
        {
            get
            {
                return 1;
            }
        }

        //ne csináljon semmit, a fal passzív
        public override void Utkozes(JatekElem jatekelem)
        {
        }

        public char Alak //csak olvasható, visszatérési értéke '\u2593'
        {
            get
            {
                return '\u2593';
            }
        }
    }
}

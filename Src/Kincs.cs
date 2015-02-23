﻿using System;
using OE.Prog2.Jatek.Jatekter;

namespace OE.Prog2.Jatek.Szabalyok
{
    class Kincs : RogzitettJatekElem
    {
        //az őséhez hasonlóan x és y és játéktér paramétereket kap, ezeket továbbítja az ősnek
        public Kincs(int x, int y, ref JatekTer ter)
            : base(x, y, ref ter)
        {
            Console.WriteLine(x + "," + y); //2. órai teszteléshez
        }

        //Mindig adjon vissza 1-et
        public override double Meret
        {
            get
            {
                return 1;
            }
        }
        
        public override void Utkozes(JatekElem jatekelem)
        {
            //Ellenőrizzük, hogy a nekiütköző (tehát a paraméterként kapott JatekElem) egy Jatekos típusú objektum-e
            if (jatekelem is Jatekos)
            {
                Jatekos jatekos = (Jatekos)jatekelem;
                //Ha igen, akkor hívjuk meg annak PontSzerez metódusát, paraméterként 50-et átadva
                jatekos.PontotSzerez(50);
                Console.WriteLine(jatekos.Nev); //2. órai teszteléshez

                //A kincs törölje önmagát a játéktérről
                ter.Torol(this);

                //törlés után maradjon a játékos a kincs helyén
                jatekos.Megy(this.X - jatekos.X, this.Y - jatekos.Y);
            }
        }
    }
}
